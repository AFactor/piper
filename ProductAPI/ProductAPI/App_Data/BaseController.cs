using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Runtime.Serialization.Json;
using System.Net;
using System.IO;
using System.Text;

namespace ProductAPI
{
    public class BaseController : ApiController
    {

        #region old code. ignore
        private const string _MILKIMAGE="MilkShotType1.jpg";
        private const string _COFFEEIMAGE = "CoffeeShotType1.jpg";

        private List<Tesco.Com.AppStore.Product.SimpleProduct> _allProducts;

        public List<Tesco.Com.AppStore.Product.SimpleProduct> AllProducts
        {
            get
            {
                if (null == _allProducts)
                {
                    var productData = System.IO.File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory  + @"/App_Data/productdata.csv").ToList();
                    productData.RemoveAt(0);
                    _allProducts = new List<Tesco.Com.AppStore.Product.SimpleProduct>(productData.Count);
                    var rand = new Random(1);

                    foreach (var pagedProduct in productData)
                    {
                        //$id,StoreId,ProductId,IsForSale,Price,UnitPrice,PlaceOfOrigin,Title,Description,UnitOfMeasure,DefaultImageUrl,DisplayType,AverageWeight,Taxonomy
                        var productRow = pagedProduct.Split(',').ToList();
                        var sp = new Tesco.Com.AppStore.Product.SimpleProduct();
                        sp.StoreId = productRow[1];
                        sp.ProductId = productRow[2];
                        sp.Price = decimal.Parse((rand.Next(200) + rand.NextDouble()).ToString(),System.Globalization.NumberStyles.Currency);
                        sp.Title = productRow[7];
                        sp.DefaultImageUrl = productRow[8].ToUpper().Contains("MILK") ? _MILKIMAGE : _COFFEEIMAGE;
                        sp.AverageWeight = (rand.Next(200) + rand.NextDouble());
                        sp.Description = productRow[8];
                        sp.DisplayType = productRow[11];
                        sp.IsForSale = true;
                        sp.PlaceOfOrigin = productRow[6];
                        sp.Taxonomy = new Tesco.Com.AppStore.Product.WebTaxonomy() { Id = "Cat001", Name = "TestTaxonomy" };
                        _allProducts.Add(sp);
                    }
                }
                return _allProducts;
            }
        }
 #endregion 

        protected T FromUri<T>(string uri, HttpVerbs verb, string data, params object[] queryParams)
        {


            var obj = Activator.CreateInstance<T>();
            if (null != queryParams)
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
    }
}
