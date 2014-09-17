//using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tesco.Com.Pipeline.Entities.ProductEntities;
using Tesco.Com.Pipeline.Provider;
using Tesco.Com.Pipeline.Operations;
namespace Tesco.Com.Pipeline.Operations.Price
{
    
    public class PriceByIdOperation : ApiOperation<ResultETL>
    {        
        
        public override IEnumerable<ResultETL> Execute(IEnumerable<ResultETL> input)
        {
            var productIds = input.Select(m => m.ProductId).ToList();
            var body = productIds.Select(p => @"{""ProductId"":" + "\"" + p.ToString() + "\"" + "}").ToList();
            var bodyText = string.Format("[{0}]", string.Join(",", body));
            ParamArray = new string[] { System.DateTime.Now.ToString("yyyy-MM-dd"), 
                System.DateTime.Now.AddDays(7).ToString("yyyy-MM-dd"), "none" };

            var result = (List<PriceResult>)FromApi("PriceByProductIds", bodyText,
                ParamArray);
            var price= result.FirstOrDefault();
            List<ResultETL> products = new List<ResultETL>();
            foreach (ResultETL resultDetail in input)
            {
                var linePrice = price.LinePrices.FirstOrDefault(l => l.ProductId.Contains(resultDetail.ProductId));
                if (null != linePrice)
                {
                    resultDetail.Uom = price.LinePrices.FirstOrDefault(l => l.ProductId.Contains(resultDetail.ProductId)).Uom;
                    resultDetail.Quantity = price.LinePrices.FirstOrDefault(l => l.ProductId.Contains(resultDetail.ProductId)).Quantity;
                    resultDetail.TotalSellingPrice = price.LinePrices.FirstOrDefault(l => l.ProductId.Contains(resultDetail.ProductId)).TotalSellingPrice.Amount;
                    resultDetail.UnitSellingPrice = price.LinePrices.FirstOrDefault(l => l.ProductId.Contains(resultDetail.ProductId)).UnitSellingPrice.Amount;
                }
            }
            return input;
        }
    }


}