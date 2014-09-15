using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Tesco.Com.Pipeline
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            //config.Routes.MapHttpRoute(null, "api/Products/Search/{queryText}",
            //   new
            //   {
            //       queryText = UrlParameter.Optional,
            //       //pageNumber = UrlParameter.Optional,
            //       //sort = UrlParameter.Optional,
            //       //perpage = UrlParameter.Optional,
            //       controller = "ProductPrice",
            //       action = "Search"
            //   });

            config.Routes.MapHttpRoute(null, "Navigation/",
                new
                {
                    controller = "Navigation",
                    action = "Get"
                });

            config.Routes.MapHttpRoute(null, "ProductBrowse/",
                new
                {
                    controller = "ProductBrowse",
                    action = "GetProductList"
                });

            config.Routes.MapHttpRoute(null, "DeviceIdentification/",
                new
                {
                    controller = "DeviceIdentification",
                    action = "GetDeviceFamily"
                });
            
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            var settings = json.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
