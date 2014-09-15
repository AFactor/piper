using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web;
using System.Web.Mvc;
using ProductAPI.Provider.Contract;
using ProductAPI.Entities.ProductEntities;
namespace ProductAPI.Provider.GAPI
{
    public class GapiPriceProvider:BaseProvider, IPriceProvider
    {

        public PriceResult CalculateTotal(List<string> productIds, string zone, DateTime? validFrom, DateTime? validTill, string applicablePromotionTypes)
        {
            

            var body = productIds.Select(p => @"{""ProductId"":" + "\"" + p.ToString() + "\"" + "}").ToList();
            var bodyText = string.Format("[{0}]", string.Join(",", body));

            var result = (List<ProductAPI.Entities.ProductEntities.PriceResult>)FromApi("PriceByProductIds", bodyText,
                new string[] { validFrom.Value.ToString("yyyy-MM-dd"), validTill.Value.ToString("yyyy-MM-dd"), applicablePromotionTypes });
            return result.FirstOrDefault();
        }
    }
}