using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Tesco.Com.Pipeline.Controllers
{
    public class BaseController : ApiController
    {
        //protected T FromUri<T>(string uri, HttpVerbs verb, string data, params object[] queryParams)
        //{
        //    var obj = Activator.CreateInstance<T>();
        //    if (null != queryParams)
        //        uri = String.Format(uri, queryParams);
        //    var json = string.Empty;
        //    WebClient client = new WebClient();
        //    //add header
        //    client.Headers.Add("authorization",
        //        "appKeyToken=DotnetHostUser001&appKey=F28AE227-529A-488D-A955-A0CD0048EC89&,");
        //    client.Headers.Add("accept", "application/json");
        //    client.Headers.Add("Content-Type", "application/json");

        //    if (verb.Equals(HttpVerbs.Get))
        //        json = client.DownloadString(uri);
        //    else
        //        json = client.UploadString(uri, data);
        //    MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
        //    DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
        //    obj = (T)serializer.ReadObject(ms);
        //    ms.Close();
        //    return obj;
        //}
    }
}
