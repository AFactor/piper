using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;

namespace Tesco.Com.Pipeline.Utilities
{
    public class ApiException : Exception
    {
        public ApiException(){}

        public ApiException(HttpStatusCode code, HttpResponseHeaders headers):base("Api returned error with status code " + code + ". Check headers for details.")
        {
            StatusCode = code;
            Headers = headers;
            
        }
        public HttpStatusCode StatusCode { get; set; }
        public HttpResponseHeaders Headers { get; set; }

    }
}