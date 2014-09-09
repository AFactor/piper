using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
namespace ProductAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableSystemDiagnosticsTracing();

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);


            config.Routes.MapHttpRoute(null, "api/Products/Search/query={queryText}/required={requiredProperties}/region={region}/language={language}/storeid={storeId}/sort={sort}/facets={facetIds}/page={pageNumber}/perpage={perpage}",
            new { queryText = UrlParameter.Optional, requiredProperties = UrlParameter.Optional, facetIds=UrlParameter.Optional, pageNumber = UrlParameter.Optional,
                  region = UrlParameter.Optional,
                  language = UrlParameter.Optional,
                  storeId = UrlParameter.Optional,
                  sort = UrlParameter.Optional,
                  perpage=UrlParameter.Optional,
                controller = "Products", action = "Search" });

            config.Routes.MapHttpRoute(null, "api/Products/Search/query={queryText}/sort={sort}/page={pageNumber}/perpage={perpage}",
            new
            {
                queryText = UrlParameter.Optional,                
                pageNumber = UrlParameter.Optional,                
                sort = UrlParameter.Optional,
                perpage = UrlParameter.Optional,
                controller = "ProductPrice",
                action = "Search"
            });

            config.Routes.MapHttpRoute(null, "api/Products/Search/{queryText}",
           new
           {
               queryText = UrlParameter.Optional,
               //pageNumber = UrlParameter.Optional,
               //sort = UrlParameter.Optional,
               //perpage = UrlParameter.Optional,
               controller = "ProductPrice",
               action = "Search"
           });

            config.Routes.MapHttpRoute(null, "api/Products/Navigation/region={region}/language={language}/storeid={storeId}",
            new
            {              
                region = UrlParameter.Optional,
                language = UrlParameter.Optional,
                storeId = UrlParameter.Optional,             
                controller = "Products",
                action = "Navigation"
            });

            config.Routes.MapHttpRoute(null, "api/Device/UserAgent={userAgent}",
            new
            {                
                userAgent = UrlParameter.Optional,
                controller = "Device",
                action = "Identification"
            });
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
