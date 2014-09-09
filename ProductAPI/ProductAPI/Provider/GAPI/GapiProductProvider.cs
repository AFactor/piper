using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductAPI.Provider.Contract;
namespace ProductAPI.Provider.GAPI
{
    public class GapiProductProvider : BaseProvider, IProductProvider
    {
        
        public Entities.ProductEntities.ProductResult Search(string q, string[] fields, string orderByFields, int? offset, int? limit)
        {            

            var result = (Entities.ProductEntities.ProductResult)FromApi("ProductSearch",  string.Empty, new string[] { q, orderByFields, offset.Value.ToString(), limit.Value.ToString() });
            return result;
        }

    }
}