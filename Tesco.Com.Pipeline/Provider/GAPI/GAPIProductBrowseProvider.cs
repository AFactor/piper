using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Tesco.Com.Pipeline.Entities.RequestEntities;
using Tesco.Com.Pipeline.Provider.Contract;

namespace Tesco.Com.Pipeline.Provider.GAPI
{
    public class GAPIProductBrowseProvider : BaseProvider, IProductBrowseProvider
    {
        public Entities.ProductList GetProductList(string query, string offset, string limit, string orderByFields, string business)
        {
            Entities.ProductList productlist = null;
            List<uint> productIds = new List<uint>();

            // Fetch ProductIds for requested ProductBrowse page
            productlist = (Entities.ProductList)FromApi("AnonymousProductBrowseRangeSearch", string.Empty,
                new string[] { query, offset, limit, orderByFields, business });
            
            if (productlist != null && productlist.ResultSubSet != null)
            {
                StringBuilder q = new StringBuilder("productids=");
                foreach (var prod in productlist.ResultSubSet)
                {
                    q.Append(prod.ProductId).Append(",");
                    productIds.Add(prod.ProductId);
                }

                // remove last comma from the string
                q.Remove(q.Length - 1, 1);

                // Fetch Price for List of ProductIds make it Async
                var body = productIds.Select(p => @"{""ProductId"":" + "\"" + p.ToString() + "\"" + "}").ToList();
                var bodyText = string.Format("[{0}]", string.Join(",", body));

                Entities.ProductPrice productPrice = (Entities.ProductPrice)FromApi("AnonymousProductBrowsePrice", bodyText,
                    new string[] { DateTime.Today.ToString("yyyy-MM-dd"), DateTime.Today.ToString("yyyy-MM-dd"), "None", business });

                // Fetch Product properties for a list of ProductIds, make it Async
                Entities.ProductSearchResult productSearchResult = (Entities.ProductSearchResult)FromApi("AnonymousProductBrowseProductSearch", string.Empty,
                    new string[] { q.ToString(), offset, limit, orderByFields, business });

                if (productSearchResult!= null && productSearchResult.TotalMatchedCount > 0)
                {
                    foreach (var prod in productSearchResult.Results)
                    {
                        //prod.
                    }
                }
            }

            return productlist;
        }
    }
}