using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tesco.Com.Pipeline.Entities.ProductEntities;
using Tesco.Com.Pipeline.Provider.Contract;
using Tesco.Com.Pipeline.Provider.GAPI;
using Tesco.Com.Pipeline.Utilities;
using System.Threading.Tasks;
using Tesco.Com.Pipeline.Pipe;

namespace Tesco.Com.Pipeline.Controllers
{
    /// <summary>
    /// This is the controller for all product,price and pormotion related operations
    /// </summary>
    public class ProductETLController : ApiController
    {
        
        

        public ProductETLController() { }
       

        [System.Web.Http.HttpGet]
        public IEnumerable<ResultETL> Search(string queryText, int pageNumber, string sort, int perPage)
        {
            try
            {
                Logger.InfoFormat("Product search request received. Searching for {0}. Sorting by {1}. page ={2}, per page={3}",queryText,sort,pageNumber, perPage);
                //TODO: get steps from config? Do u need it? Does it make sense?
                var searchResult=new SearchPipeline(queryText,  pageNumber.ToString(),sort,  perPage.ToString()).Execute();                
                return  searchResult;
            }
            catch (Exception ex)
            {
                //need to do something here.
                Logger.Error("Search", ex);
                throw;
            }

        }


        
    }
}

