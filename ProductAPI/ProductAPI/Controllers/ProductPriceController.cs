using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tesco.Com.Core.Contracts;
using System.Web.Mvc;
using Tesco.Com.AppStore.Product;
using System.IO;
using System.Reflection;
using System.Text;
using System.Configuration;
using ProductAPI.Entities.ProductEntities;
using System.Runtime.Serialization.Json;
using log4net;
using ProductAPI;
using System.Threading.Tasks;
using ProductAPI.Provider.Contract;
using ProductAPI.Provider.GAPI;

namespace ProductAPI.Controllers
{
    public class ProductPriceController : ApiController
    {
        //TODO: Unity
        IProductProvider productProvider = new GapiProductProvider();
        IPriceProvider priceProvider = new GapiPriceProvider();
        IPromotionProvider promotionProvider = new GapiPromotionProvider();

        [System.Web.Http.HttpGet]       
        public ProductResult Search(string queryText,  int pageNumber, string sort,  int perPage)
        {
            try
            {
                Logger.Info("Request received");
                //TODO: get steps from config
                var products = productProvider.Search(queryText, null, sort, pageNumber, perPage);
                var promos=new List<PromotionObject>();
                var prices=new PriceResult();
                #region parallel
                Parallel.Invoke(() =>
                        {
                            prices = priceProvider.CalculateTotal(products.Results.Select(m => m.ProductId).ToList(),
                                null, DateTime.Now, DateTime.Now.AddDays(7), "none");
                        },
                    () =>
                    {
                        var ids = "productIds:" + string.Join(",", products.Results.Select(m => m.ProductId));
                        //limit and offset doesn't matter, will be determined by product
                        promos = promotionProvider.Search(ids, null, 1000, 0);
                    });
                #endregion
                #region sync
                //prices = priceProvider.CalculateTotal(products.Results.Select(m => m.ProductId).ToList(),
                //                null, DateTime.Now, DateTime.Now.AddDays(7), "None");
                //var ids = "productIds:" + string.Join(",", products.Results.Select(m => m.ProductId));
                ////limit and offset doesn't matter, will be determined by product
                //promos = promotionProvider.Search(ids, null, 1000, 0);
                #endregion

                Mix(products, prices, promos);
                Logger.Info("Mixing done");
                return products;
                
            }
            catch (Exception ex)
            {
                //need to do something here.
                Logger.Error("Search",ex);
                throw;
            }
          
        }

        
        private void Mix(ProductResult products, PriceResult prices, List<PromotionObject> promos )
        {
            //commented code is me going overdrive with threading. Did not see a perf benefit even with 1000 products.
            //Parallel.ForEach(promos, p =>
            //{
            //    var pId = p.Buckets.FirstOrDefault().Attachments.FirstOrDefault(a => (a.Type == "productid")).Value;
            //    p.ProductId = pId;
            //});
            foreach (PromotionObject p in promos)
            {
                var pId = p.Buckets.FirstOrDefault().Attachments.FirstOrDefault(a => (a.Type == "productid")).Value;
                p.ProductId = pId;
            }

            //Parallel.ForEach(products.Results, r =>
            foreach (Result r in products.Results)
            {
                r.Price = prices.LinePrices.FirstOrDefault(l => l.ProductId.Contains(r.ProductId));
                r.Promotion = promos.FirstOrDefault(pr => pr.ProductId == r.ProductId);
            }//);
        }

        private T FromUri<T>(string uri, HttpVerbs verb, string data, params object[] queryParams)
        {


            var obj = Activator.CreateInstance<T>();
            if(null!=queryParams)
                uri = String.Format(uri, queryParams);
            var json = string.Empty;
            WebClient client = new WebClient();
           //add header
            client.Headers.Add("authorization",
                "appKeyToken=DotnetHostUser001&appKey=F28AE227-529A-488D-A955-A0CD0048EC89&,");
            client.Headers.Add("accept", "application/json");
            client.Headers.Add("Content-Type", "application/json");

            if (verb.Equals(HttpVerbs.Get))
                json = client.DownloadString(uri);
            else
                json = client.UploadString(uri, data);
            MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            obj = (T)serializer.ReadObject(ms);
            ms.Close();
            return obj;
        }

        private string RequestFor(string url)
        {
            HttpWebResponse webResponse = null;
            string errorMessage = string.Empty;
            string response = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "HttpGet";
            string proxy = ConfigurationManager.AppSettings["proxy"]; // Internet access is not required when hitting DBT
            //request.Proxy = new WebProxy(proxy, true);
            request.Headers.Add("Authorization", "appKeyToken=DotnetHostUser001&appKey=F28AE227-529A-488D-A955-A0CD0048EC89&appKeyToken=DotnetHostUser001&appKey=F28AE227-529A-488D-A955-A0CD0048EC89&");
            request.Accept = "application/json";
            request.ContentType = "application/json";

            
            try
            {
                webResponse = (HttpWebResponse)request.GetResponse();
                StreamReader responseStream = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8);
                response = responseStream.ReadToEnd();
                webResponse.Close();
                responseStream.Close();
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError && ex.Response != null)
                {
                    using (WebResponse resp = ex.Response)
                    {
                        HttpWebResponse httpresponse = (HttpWebResponse)resp;
                        if (httpresponse.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            // Token has expired
                        }
                        else if (httpresponse.StatusCode == HttpStatusCode.InternalServerError || httpresponse.StatusCode == HttpStatusCode.BadRequest)
                        {
                            errorMessage = httpresponse.Headers["X-TescoMessage"] == null ? ex.Message : httpresponse.Headers["X-TescoMessage"].ToString();
                            //Helper.LogInfo(result, new SessionData(), errorMessage);
                        }
                        else
                        {
                            errorMessage = httpresponse.Headers["X-TescoMessage"] == null ? ex.Message : httpresponse.Headers["X-TescoMessage"].ToString();
                            //Helper.LogInfo(result, new SessionData(), errorMessage);
                        }
                    }
                }
            }

            return response;
        }
        
    }
}

