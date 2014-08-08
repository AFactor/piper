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

namespace Tesco.Com.Pipeline.Provider
{
    public class BaseProvider
    {
        protected object FromUri(string uri, HttpVerbs verb, string entityType, string entityAssembly, string body = "", bool isGenericType = false)
        {
            //TODO:Cleaner code here
            ObjectHandle handle = Activator.CreateInstance(entityAssembly, entityType);
            var obj = handle.Unwrap();
            Type t = obj.GetType();
            //only list is supported
            if (isGenericType)
                obj = Utilities.HelperMethods.CreateGeneric(typeof(List<>), t);

            var json = string.Empty;
            WebClient client = new WebClient();
            //todo: remove hard code authetication. Use request headers
            client.Headers.Add("authorization",
                "appKeyToken=DotnetHostUser001&appKey=F28AE227-529A-488D-A955-A0CD0048EC89&,");
            client.Headers.Add("accept", "application/json");
            client.Headers.Add("Content-Type", "application/json");
            //--
            Logger.Info("Body: " + body);
            Logger.Info("uir: " + uri);
            if (verb.Equals(HttpVerbs.Get))
                json = client.DownloadString(uri);
            else
                json = client.UploadString(uri, body);
            MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            obj = serializer.ReadObject(ms);
            ms.Close();
            return obj;
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