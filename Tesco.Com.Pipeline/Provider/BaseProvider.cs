using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Tesco.Com.Pipeline.API;
using Tesco.Com.Pipeline.Utilities;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Configuration;
using Tesco.Com.Pipeline.Utilities;

namespace Tesco.Com.Pipeline.Provider
{
    public class BaseProvider
    {
        protected object FromUri(string uri, HttpVerbs verb, string entityType, string entityAssembly, string body = "", bool isGenericType = false)
        {
            try
            {
                //TODO:Cleaner code here
                ObjectHandle handle = Activator.CreateInstance(entityAssembly, entityType);
                var obj = handle.Unwrap();
                Type t = obj.GetType();
                //only list is supported
                if (isGenericType)
                    obj = Utilities.HelperMethods.CreateGeneric(typeof(List<>), t);

                Stream apiStream;

                var httpClientHandler = new HttpClientHandler
                {
                    Proxy = ConfigurationManager.AppSettings["proxy"].Equals("default") || string.IsNullOrEmpty(ConfigurationManager.AppSettings["proxy"]) ?
                    WebRequest.DefaultWebProxy :
                    new WebProxy(ConfigurationManager.AppSettings["proxy"], false),
                    UseProxy = true

                };

                //TODO: read up HttpCleint and refactor
                HttpResponseMessage response = new HttpResponseMessage();
                
                using (HttpClient client = new HttpClient(httpClientHandler, true))
                {
                    client.DefaultRequestHeaders.Add("accept", "application/json");
                    ////todo: remove hard code authetication. Use request headers
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "appKeyToken=DotnetHostUser001&appKey=F28AE227-529A-488D-A955-A0CD0048EC89&");
                    Logger.Info(string.Format("Logging Request: uri: {0}. Body: {1}.", uri, body));

                    //TODO: Add delete
                    switch (verb)
                    {
                        case HttpVerbs.Post:
                        case HttpVerbs.Put:
                            using (HttpContent content = new StringContent(body))
                            {
                                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                                response = client.PostAsync(uri, content).Result;
                            }

                            break;
                        default:
                            response = client.GetAsync(uri).Result;
                            break;
                    }

                }
                if (response.IsSuccessStatusCode)
                    apiStream = response.Content.ReadAsStreamAsync().Result;
                else
                {

                    throw new ApiException(response.StatusCode, response.Headers);

                }
                
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                obj = serializer.ReadObject(apiStream);
                response.Dispose();
                apiStream.Close();
                apiStream.Dispose();
                return obj;
            }
            catch(ApiException apx)
            {                
                string exceptionDetails = ". Exception Details : ";
                string statusCode = apx.StatusCode.ToString();
                var values = apx.Headers.GetValues("X-TescoMessage");
                if (values != null)
                {
                    foreach (var item in values)
                    {
                        exceptionDetails += item;
                    }
                }
                
                string errorMsg = String.Concat(apx.Message, " Code: ", statusCode, exceptionDetails);
                throw new ApplicationException(errorMsg);
            }
        }



        protected object FromApi(string name, string body, params string[] queryParams)
        {
            ApiConfigurationElement element = ApiHelper.GetApiForKey(name, "gapi");
            if (element != null)
            {
                if (queryParams.Count() < element.ParamCount)
                {
                    throw new ArgumentException("Incorrect number of parameters passed");
                }

                var uri = String.Format(element.Uri, queryParams);
                HttpVerbs verb;
                Enum.TryParse(element.Verb, true, out verb);

                //Type entityType = Type.GetType(element.Type);
                var entityType = element.Type;
                var entityAssembly = element.TypeAssembly;
                return FromUri(uri, verb, entityType, entityAssembly, body, element.IsList);
            }
            return null;
        }
    }
}