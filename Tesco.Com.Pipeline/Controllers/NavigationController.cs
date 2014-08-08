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

namespace Tesco.Com.Pipeline.Controllers
{
    public class NavigationController : ApiController
    {
        INavigationProvider navigationProvider = new GAPINavigationProvider();

        [System.Web.Http.HttpGet]
        public Hierarchy Get(string type, string taxonomyId="", string storeId="", string business="Grocery")
        {
            try
            {
                Logger.Info("Request received");
                //TODO: make it async              
                //CHECK IF NO STORE ID AND IS ANNOMOUS. IF YES, PASS IT TO THE OTHER GET
                Hierarchy hierarchy;
                if (string.IsNullOrEmpty(storeId))
                {
                    return Get(type, taxonomyId, business);
                }
                else
                {
                    hierarchy = navigationProvider.GetNavigation(type, taxonomyId, business, storeId);
                }
                return hierarchy;
            }
            catch (Exception ex)
            {
                //need to do something here.
                Logger.Error("Search", ex);
                throw;
            }
        }


        private Hierarchy Get(string type, string taxonomyId,  string business)
        {
            try
            {
                //TODO: make it async              
                var hierarchy = navigationProvider.GetNavigation(type, taxonomyId, business);
                return hierarchy;
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
