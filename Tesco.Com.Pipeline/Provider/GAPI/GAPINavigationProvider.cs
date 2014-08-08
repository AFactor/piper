using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tesco.Com.Pipeline.Entities.NavigationEntities;
using Tesco.Com.Pipeline.Provider.Contract;

namespace Tesco.Com.Pipeline.Provider.GAPI
{
    public class GAPINavigationProvider : BaseProvider, INavigationProvider
    {
        // Anonymous request
        public Hierarchy GetNavigation(string type, string taxonomyId, string business)
        {
            return (Hierarchy)FromApi("NavigationAnonymous", string.Empty,
                new string[] { type, taxonomyId, business });
        }


        // Loggedin request
        public Hierarchy GetNavigation(string type, string taxonomyId, string business, string storeId)
        {
            return (Hierarchy)FromApi("Navigation", string.Empty,
                new string[] { type, taxonomyId, business, storeId });
        }
    }
}