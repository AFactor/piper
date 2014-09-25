using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tesco.Com.Pipeline.Entities.ResponseEntities;
using Tesco.Com.Pipeline.Provider.Contract;
using Tesco.Com.Pipeline.Provider.GAPI;
using Tesco.Com.Pipeline.Utilities;
using System.Threading.Tasks;
using Tesco.Com.Pipeline.Pipe;
using Tesco.Com.Pipeline.Operations.Contract;
using Tesco.Com.Pipeline.Operations;

namespace Tesco.Com.Pipeline.Controllers
{
    public class NavigationController : ApiController
    {
        private readonly IPipeline<Navigation> _navigationPipeline;

        public NavigationController(IPipeline<Navigation> navigationPipeline)
        {
            _navigationPipeline = navigationPipeline;
        }

        [System.Web.Http.HttpGet]
        public Navigation Get(string type, string taxonomyId = "", string business = "Grocery", string storeId = "")
        {
            try
            {
                Logger.Info("Request received");
                //CHECK IF NO STORE ID AND IS ANONYMOUS. IF YES, PASS IT TO THE OTHER GET
                if (string.IsNullOrEmpty(storeId))
                {
                    return Get(type, taxonomyId, business);
                }
                else
                {
                    string[] arr = {type, taxonomyId, business, storeId};
                    IEnumerable<Navigation> navigation = _navigationPipeline.Register(arr).Execute();

                    return navigation.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                //need to do something here.
                Logger.Error("Navigation Get", ex);
                throw;
            }
        }


        private Navigation Get(string type, string taxonomyId, string business)
        {
            try
            {
                string[] arr = { type, taxonomyId, business };                         
                IEnumerable<Navigation> navigation = _navigationPipeline.Register( arr).Execute();
                
                return navigation.FirstOrDefault();
            }
            catch (Exception ex)
            {
                //need to do something here.
                Logger.Error("Anonymous Navigation Get", ex);
                throw;
            }
        }
    }
}
