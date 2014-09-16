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


   


}