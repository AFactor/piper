using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tesco.Com.Core.Contracts;

using Tesco.Com.AppStore.Product;

using System.Reflection;
namespace ProductAPI.Controllers
{
    public class ProductsController : BaseController
    {
        

        
        [HttpGet]
        public Tesco.Com.AppStore.Product.SimplePagedProducts Search(string queryText,  int pageNumber, string sort,  int perPage)
        {            
            
            try
            {
             
                
                var selectedProducts = AllProducts.Where(p => p.Title.ToLower().Contains(queryText.ToLower()));
                //sort
                
                switch (sort)
                {
                    case "TitleAscending":
                        selectedProducts = selectedProducts.OrderBy(o => o.Title);
                        break;
                    case "TitleDescending":
                        selectedProducts = selectedProducts.OrderByDescending(o => o.Title);
                        break;
                    case "PriceAscending":
                        selectedProducts = selectedProducts.OrderBy(o => o.Price);
                        break;
                    case "PriceDescending":
                        selectedProducts = selectedProducts.OrderByDescending(o => o.Price);
                        break;
                }

                selectedProducts = selectedProducts.Skip((pageNumber - 1) * perPage);
                selectedProducts=selectedProducts.Take(perPage);

                var s = new SimplePagedProducts(selectedProducts.ToList(),
                    new PagingAndSorting() { Skip = (pageNumber-1) * perPage, Take = perPage, SortOrder = new[] { sort }, TotalCount = AllProducts.Where(p => p.Title.ToLower().Contains(queryText.ToLower())).Count() });//,correlationId);
                return s;

            }
            catch(Exception ex)
            {
                throw;
            }
        }

       

        

        
        

        
    }
}

