using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tesco.Com.Pipeline.Entities.NavigationEntities;
using Tesco.Com.Pipeline.Provider.Contract;
using Tesco.Com.Pipeline.Provider.GAPI;
using Tesco.Com.Pipeline.Utilities;
using System.Threading.Tasks;

namespace Tesco.Com.Pipeline.Controllers
{
    public class NavigationController : ApiController
    {
        private readonly INavigationProvider _navigationProvider;

        public NavigationController() { }

        public NavigationController(INavigationProvider navigationProvider)
        {
            _navigationProvider = navigationProvider;
        }


        [System.Web.Http.HttpGet]
        public Hierarchy Get(string type, string taxonomyId = "", string business = "Grocery", string storeId = "")
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
                    return _navigationProvider.GetNavigation(type, taxonomyId, business, storeId);
                }

            }
            catch (Exception ex)
            {
                //need to do something here.
                Logger.Error("Navigation Get", ex);
                throw;
            }
        }


        private Hierarchy Get(string type, string taxonomyId, string business)
        {
            try
            {
                return _navigationProvider.GetNavigation(type, taxonomyId, business);
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
