using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Remoting;
using System.Runtime.Serialization.Json;
using System.Web.Mvc;
using Tesco.Com.Pipeline.API;
using Tesco.Com.Pipeline.Utilities;

namespace Tesco.Com.Pipeline.Operations
{


    public abstract class BaseOperation<T>
    {
        
        
        public string[] ParamArray { get; set; }
        public abstract IEnumerable<T> Execute(IEnumerable<T> input);
        

      
    }

}
