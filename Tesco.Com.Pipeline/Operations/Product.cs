//using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tesco.Com.Pipeline.Entities.ProductEntities;
using Tesco.Com.Pipeline.Provider;
using Tesco.Com.Pipeline.Operations;
namespace Tesco.Com.Pipeline.Operations.Product
{
    public class ProductSearchOperation : ApiOperation<ResultETL>
    { 
        public override IEnumerable<ResultETL> Execute(IEnumerable<ResultETL> input)
        {
            var result = (ProductResult)FromApi("ProductSearch", string.Empty, ParamArray);
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



    public class ProductsByIdsOperation : ApiOperation<ResultETL>
    {
        public override IEnumerable<ResultETL> Execute(IEnumerable<ResultETL> input)
        {
            //var offset="1"; var limit="10"; var order="Productinfo,Default"; var business="grocery";
            var productIds =new System.Text.StringBuilder("productids=")
                .Append(string.Join(",", input.Select(i => i.ProductId))).ToString();
            //ParamArray = new string[] { productIds, offset, limit, order, business };
            ParamArray[0] = productIds;
            var result = (ProductResult)FromApi("AnonymousProductBrowseProductSearch", string.Empty,ParamArray);


            
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
}