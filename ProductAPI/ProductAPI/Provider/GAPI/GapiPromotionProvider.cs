using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductAPI.Provider.Contract;
using ProductAPI.Entities.ProductEntities;
namespace ProductAPI.Provider.GAPI
{
    public class GapiPromotionProvider : BaseProvider, IPromotionProvider
    {
        
       


        public List<PromotionObject> Search(string q, string[] fields, int? limit, int? offset)
        {
            var uri = "http://172.25.58.107:67/v1/Promotion/search?q={0}&limit={1}&offset={2}&business=grocery";

            var result = (List<PromotionObject>)FromApi("PromotionByProductIds", string.Empty, new string[] { q, limit.Value.ToString(), offset.Value.ToString() });

            return result;
        }
    }
}

