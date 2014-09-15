using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tesco.Com.Pipeline.Entities.NavigationEntities;

namespace Tesco.Com.Pipeline.Provider.Contract
{
    public interface INavigationProvider
    {
        // For anonymous request
        Hierarchy GetNavigation(string type, string taxonomyId, string business);

        // Loggedin customer request
        Hierarchy GetNavigation(string type, string taxonomyId, string business, string storeId);
    }
}
