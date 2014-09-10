using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tesco.Com.Pipeline.Entities.ProductEntities;
using Tesco.Com.Pipeline.Provider.Contract;
using Tesco.Com.Pipeline.Provider.GAPI;
using Tesco.Com.Pipeline.Utilities;
using System.Threading.Tasks;

namespace Tesco.Com.Pipeline.Controllers
{
    /// <summary>
    /// This is the controller for all product,price and pormotion related operations
    /// </summary>
    public class ProductController : ApiController
    {
        
        private readonly IProductProvider _productProvider;
        private readonly IPriceProvider _priceProvider;
        private readonly IPromotionProvider _promotionProvider;


        public ProductController() { }
        public ProductController(IProductProvider product, IPriceProvider price, IPromotionProvider promos)
        {
            _productProvider = product;
            _priceProvider = price;
            _promotionProvider = promos;

        }

        [System.Web.Http.HttpGet]
        public List<ResultETL> Search(string queryText, int pageNumber, string sort, int perPage)
        {
            try
            {
                Logger.Info("Request received");
                //TODO: get steps from config
                var products = _productProvider.Search(queryText, null, sort, pageNumber, perPage);
                var promos = new List<PromotionObject>();
                var prices = new PriceResult();
                #region parallel
                Parallel.Invoke(() =>
                {
                    prices = _priceProvider.CalculateTotal(products.Results.Select(m => m.ProductId).ToList(),
                        null, DateTime.Now, DateTime.Now.AddDays(7), "none");
                },
                    () =>
                    {
                        var ids = "productIds:" + string.Join(",", products.Results.Select(m => m.ProductId));
                        //limit and offset doesn't matter, will be determined by product
                        promos = _promotionProvider.Search(ids, null, 1000, 0);
                    });
                #endregion
                #region sync
                //prices = priceProvider.CalculateTotal(products.Results.Select(m => m.ProductId).ToList(),
                //                null, DateTime.Now, DateTime.Now.AddDays(7), "None");
                //var ids = "productIds:" + string.Join(",", products.Results.Select(m => m.ProductId));
                ////limit and offset doesn't matter, will be determined by product
                //promos = promotionProvider.Search(ids, null, 1000, 0) ;
                #endregion

                Logger.Info("Mixing done");
                return Mix(products, prices, promos);
                
                

            }
            catch (Exception ex)
            {
                //need to do something here.
                Logger.Error("Search", ex);
                throw;
            }

        }


        private List<ResultETL> Mix(ProductResult products, PriceResult prices, List<PromotionObject> promos)
        {
            var flatProducts = new List<ResultETL>(products.Results.Count());
            foreach(Result r in products.Results)
            {
                var product=new ResultETL();
                product.ProductId = r.ProductId;
                product.BaseProductId = r.Summary.BaseProductId;
                product.Description = r.Summary.Description;
                product.Title = r.Summary.Title;
                product.Brand = r.Summary.Brand;
                //product.DateOfmanufacture = r.Summary.DateOfmanufacture;
                product.MediaUrl = r.Media.FirstOrDefault().Url;
                product.Uom  = prices.LinePrices.FirstOrDefault(l => l.ProductId.Contains(r.ProductId)).Uom;
                product.Quantity = prices.LinePrices.FirstOrDefault(l => l.ProductId.Contains(r.ProductId)).Quantity;
                product.TotalSellingPrice = prices.LinePrices.FirstOrDefault(l => l.ProductId.Contains(r.ProductId)).TotalSellingPrice.Amount;
                product.UnitSellingPrice = prices.LinePrices.FirstOrDefault(l => l.ProductId.Contains(r.ProductId)).UnitSellingPrice.Amount;
                flatProducts.Add(product);
            }
            return flatProducts;
            
            //commented code is me going overdrive with threading. Did not see a perf benefit even with 1000 products.
            //Parallel.ForEach(promos, p =>
            //{
            //    var pId = p.Buckets.FirstOrDefault().Attachments.FirstOrDefault(a => (a.Type == "productid")).Value;
            //    p.ProductId = pId;
            //});
            //foreach (PromotionObject p in promos)
            //{
            //    var pId = p.Buckets.FirstOrDefault().Attachments.FirstOrDefault(a => (a.Type == "productid")).Value;
            //    p.ProductId = pId;
            //}

            ////Parallel.ForEach(products.Results, r =>
            //foreach (Result r in products.Results)
            //{
            //    r.Price = prices.LinePrices.FirstOrDefault(l => l.ProductId.Contains(r.ProductId));
            //    r.Promotion = promos.FirstOrDefault(pr => pr.ProductId == r.ProductId);
            //}//);
        }
    }
}

