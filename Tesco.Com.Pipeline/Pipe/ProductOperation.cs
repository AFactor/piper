//using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tesco.Com.Pipeline.Entities.ProductEntities;
using Tesco.Com.Pipeline.Provider;
namespace Tesco.Com.Pipeline.Pipe
{
    public class ProductSearchOperation : BaseOperation<ResultETL>
    {
        public string[] ParamArray { get; set; }
        BaseProvider baseprovider = new BaseProvider();
        public IEnumerable<ResultETL> Execute(IEnumerable<ResultETL> input)
        {
            var result = (ProductResult)baseprovider.FromApi("ProductSearch", string.Empty, ParamArray);
            List<ResultETL> products = new List<ResultETL>();
            foreach (Result resultDetail in result.Results)
            {
                var product = new ResultETL();
                product.ProductId = resultDetail.ProductId;
                product.BaseProductId = resultDetail.Summary.BaseProductId;
                product.Description = resultDetail.Summary.Description;
                product.Title = resultDetail.Summary.Title;
                product.Brand = resultDetail.Summary.Brand;
                //product.DateOfmanufacture = r.Summary.DateOfmanufacture;
                product.MediaUrl = resultDetail.Media.FirstOrDefault().Url;

                products.Add(product);

            }
            return products;

        }
    }


    public class PriceOperation : BaseOperation<ResultETL>
    {
        public string[] ParamArray { get; set; }
        BaseProvider baseprovider = new BaseProvider();
        public IEnumerable<ResultETL> Execute(IEnumerable<ResultETL> input)
        {
            var productIds = input.Select(m => m.ProductId).ToList();
            var body = productIds.Select(p => @"{""ProductId"":" + "\"" + p.ToString() + "\"" + "}").ToList();
            var bodyText = string.Format("[{0}]", string.Join(",", body));


            var result = (List<PriceResult>)baseprovider.FromApi("PriceByProductIds", bodyText,
                ParamArray);
            var price= result.FirstOrDefault();
            List<ResultETL> products = new List<ResultETL>();
            foreach (ResultETL resultDetail in input)
            {

                resultDetail.Uom = price.LinePrices.FirstOrDefault(l => l.ProductId.Contains(resultDetail.ProductId)).Uom;
                resultDetail.Quantity = price.LinePrices.FirstOrDefault(l => l.ProductId.Contains(resultDetail.ProductId)).Quantity;
                resultDetail.TotalSellingPrice = price.LinePrices.FirstOrDefault(l => l.ProductId.Contains(resultDetail.ProductId)).TotalSellingPrice.Amount;
                resultDetail.UnitSellingPrice = price.LinePrices.FirstOrDefault(l => l.ProductId.Contains(resultDetail.ProductId)).UnitSellingPrice.Amount;
            }
            return input;
        }
    }

//    public class TerminateOperation : IOperation<ResultETL>
//    {

//        public string[] ParamArray { get; set; }
//        public IEnumerable<ResultETL> Execute(IEnumerable<ResultETL> input)
//        {
//            yield break;            
//        }
        
//    }
}