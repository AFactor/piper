using System;
using System.Collections.Generic;
using System.Web.Http;
using Tesco.Com.Pipeline.Entities.ProductEntities;
using Tesco.Com.Pipeline.Utilities;
using Tesco.Com.Pipeline.Pipe;

namespace Tesco.Com.Pipeline.Controllers
{
    /// <summary>
    /// This is the controller for all product,price and pormotion related operations
    /// </summary>
    public class ProductController : ApiController
    {
        public ProductController() { }
       
        [System.Web.Http.HttpGet]
        public IEnumerable<ResultETL> Search(string queryText, int pageNumber, string sort, int perPage)
        {
            try
            {
                Logger.InfoFormat("Product search request received. Searching for {0}. Sorting by {1}. page ={2}, per page={3}",queryText,sort,pageNumber, perPage);
                //TODO: get steps from config? Do u need it? Does it make sense?
                var searchResult = new SearchPipeline(queryText,  pageNumber.ToString(),sort,  perPage.ToString()).Execute();                
                return  searchResult;
            }
            catch (Exception ex)
            {
                //need to do something here.
                Logger.Error("Search", ex);
                throw;
            }

        }

        [System.Web.Http.HttpGet]
        public IEnumerable<ResultETL> Browse(string query, string offset, string limit, string orderByFields = "Default", string business = "Grocery")
        {
            try
            {
                Logger.InfoFormat("Product browse request received. Browsing for {0}. Sorting by {1}. page ={2}, per page={3}", query, orderByFields, offset, limit);
                //TODO: get steps from config? Do u need it? Does it make sense?
                var browseResult = new ProductBrowsePipeline(query, offset, limit, orderByFields, business).Execute();
                return browseResult;
            }
            catch (Exception ex)
            {
                //need to do something here.
                Logger.Error("Browse", ex);
                throw;
            }

        }
    }
}

