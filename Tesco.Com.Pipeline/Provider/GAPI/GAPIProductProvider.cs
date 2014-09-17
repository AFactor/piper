using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tesco.Com.Pipeline.Provider.Contract;
using Tesco.Com.Pipeline.Entities.ProductEntities;

namespace Tesco.Com.Pipeline.Provider.GAPI
{
    public class GAPIProductProvider : BaseProvider, IProductProvider
    {
        
        public Entities.ProductEntities.ProductResult Search(string q, string[] fields, string orderByFields, int? offset, int? limit)
        {            

            var result = (ProductResult)FromApi("ProductSearch",  string.Empty, new string[] { q, orderByFields, offset.Value.ToString(), limit.Value.ToString() });
            return result;
        }

    }
}