using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tesco.Com.Pipeline.Provider.Contract;

namespace Tesco.Com.Pipeline.Provider.GAPI
{
    public class GAPIProductBrowseProvider : BaseProvider, IProductBrowseProvider
    {
        public Entities.ProductList GetProductList(string query, string offset, string limit, string business)
        {
            return (Entities.ProductList)FromApi("AnonymousProductBrowse", string.Empty,
                new string[] { query, offset, limit, business });
        }
    }
}