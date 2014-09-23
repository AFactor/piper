using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Tesco.Com.Pipeline.Provider.Contract;
using Tesco.Com.Pipeline.Entities.ProductEntities;

namespace Tesco.Com.Pipeline.Provider.GAPI
{
    public class GAPIPromotionProvider : BaseProvider, IPromotionProvider
    {
        
       


        public List<PromotionObject> Search(string q, string[] fields, int? limit, int? offset)
        {
            //var uri = "http://172.25.58.107:67/v1/Promotion/search?q={0}&limit={1}&offset={2}&business=grocery";

            return (List<PromotionObject>)FromApi("PromotionByProductIds", string.Empty,
               new string[] { q, limit.Value.ToString(), offset.Value.ToString() });

            
        }
    }
}

