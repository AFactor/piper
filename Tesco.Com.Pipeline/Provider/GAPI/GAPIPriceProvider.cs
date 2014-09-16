using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tesco.Com.Pipeline.Provider.Contract;
using Tesco.Com.Pipeline.Entities.ProductEntities;

namespace Tesco.Com.Pipeline.Provider.GAPI
{
    public class GAPIPriceProvider:BaseProvider, IPriceProvider
    {

        public PriceResult CalculateTotal(List<string> productIds, string zone, DateTime? validFrom, DateTime? validTill, string applicablePromotionTypes)
        {
            

            var body = productIds.Select(p => @"{""ProductId"":" + "\"" + p.ToString() + "\"" + "}").ToList();
            var bodyText = string.Format("[{0}]", string.Join(",", body));

            
            var result = (List<PriceResult>)FromApi("PriceByProductIds", bodyText,
                new string[] { validFrom.Value.ToString("yyyy-MM-dd"), validTill.Value.ToString("yyyy-MM-dd"), applicablePromotionTypes });
            return result.FirstOrDefault();
        }
    }
}