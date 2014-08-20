using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace Tesco.Com.Pipeline
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes


            config.Routes.MapHttpRoute(null, "Products/Search/{queryText}/",//?sort={sort}/page={pageNumber}/perpage={perpage}",
            new
            {
                queryText = UrlParameter.Optional,
                //pageNumber = UrlParameter.Optional,
                //sort = UrlParameter.Optional,
                //perpage = UrlParameter.Optional,
                controller = "Product",
                action = "Search"
            });

            config.Routes.MapHttpRoute(null, "Navigation/",
                new
                {
                    controller = "Navigation",
                    action = "Get"
                });

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
