using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Tesco.Com.Pipeline.Entities.RequestEntities;
using Tesco.Com.Pipeline.Entities.ResponseEntities;
using Tesco.Com.Pipeline.Provider.Contract;

namespace Tesco.Com.Pipeline.Provider.GAPI
{
    public class GAPIProductBrowseProvider : BaseProvider, IProductBrowseProvider
    {
        private const string IMAGEHEIGHTWIDTH225 = "225";
        private const string IMAGEHEIGHTWIDTH540 = "540";

        public List<Entities.ResponseEntities.ProductBrowse> GetProductList(string query, string offset, string limit, string orderByFields, string business)
        {
            List<ProductBrowse> lstProductBrowse = new List<ProductBrowse>();
            Entities.ProductList productlist = null;
            List<uint> productIds = new List<uint>();

            // Fetch ProductIds for requested ProductBrowse page
            productlist = (Entities.ProductList)FromApi("AnonymousProductBrowseRangeSearch1", string.Empty,
                new string[] { query, offset, limit, orderByFields, business });
            
            if (productlist != null && productlist.ResultSubSet != null)
            {
                StringBuilder q = new StringBuilder("productids=");
                foreach (var prod in productlist.ResultSubSet)
                {
                    q.Append(prod.ProductId).Append(",");
                    productIds.Add(prod.ProductId);
                }

                // remove last comma from the string
                q.Remove(q.Length - 1, 1);

                // Fetch Price for List of ProductIds make it Async
                var body = productIds.Select(p => @"{""ProductId"":" + "\"" + p.ToString() + "\"" + "}").ToList();
                var bodyText = string.Format("[{0}]", string.Join(",", body));

                List<Entities.PriceResult> productPrice = (List<Entities.PriceResult>)FromApi("AnonymousProductBrowsePrice", bodyText,
                    new string[] { DateTime.Today.ToString("yyyy-MM-dd"), DateTime.Today.ToString("yyyy-MM-dd"), "None", business });

                // Fetch Product properties for a list of ProductIds, make it Async
                Entities.ProductSearchResult productSearchResult = (Entities.ProductSearchResult)FromApi("AnonymousProductBrowseProductSearch1", string.Empty,
                    new string[] { q.ToString(), offset, limit, "Productinfo," + orderByFields, business });

                if (productSearchResult!= null && productSearchResult.TotalMatchedCount > 0)
                {
                    ProductBrowse productBrowse;
                    foreach (var prod in productSearchResult.Results)
                    {
                        productBrowse = new ProductBrowse();
                        productBrowse.ProductId = prod.ProductId;
                        productBrowse.BaseProductId = prod.Identifiers.BaseProductId;
                        productBrowse.Title = prod.Summary.Title;
                        if (prod.Summary != null && prod.Summary.Type != null && prod.Summary.Type.ProductSummaryType != null 
                            && !string.IsNullOrEmpty(prod.Summary.Type.ProductSummaryType.Id) 
                            && prod.Summary.Type.ProductSummaryType.Id == "VariantType")
                        {
                            productBrowse.VariantType = prod.Summary.Type.ProductSummaryType.Value;
                        }

                        if (prod.Media != null)
                        {
                            Media media = new Media();
                            foreach(var attribute in prod.Media)
                            {
                                if (attribute.Type == "AlternativeImage")
                                {
                                    Entities.MediaImage mediaImage = JsonConvert.DeserializeObject<Entities.MediaImage>(attribute.Url.Replace("@", ""));

                                    if (mediaImage != null && mediaImage.AlternativeImageSizes != null && 
                                        mediaImage.AlternativeImageSizes.Images != null && 
                                        mediaImage.AlternativeImageSizes.Images.ImageMetaData != null)
                                    {
                                        List<Image> images = new List<Image>();
                                        Image image;
                                        foreach (var item in mediaImage.AlternativeImageSizes.Images.ImageMetaData)
                                        {
                                            if ((item.height == IMAGEHEIGHTWIDTH225 && item.width == IMAGEHEIGHTWIDTH225) ||
                                                (item.height == IMAGEHEIGHTWIDTH540 && item.width == IMAGEHEIGHTWIDTH540))
                                            {
                                                image = new Image();
                                                image.Height = item.height;
                                                image.Width = item.width;
                                                image.Url = item.url;
                                                images.Add(image);
                                            }
                                        }
                                        media.Images = images;
                                    }
                                }
                            }
                            productBrowse.Media = media;
                        }

                        foreach(var attribute in prod.CustomAttributes)
                        {
                            if (attribute.Name == "UnitQuantity")
                            {
                                productBrowse.UnitQuantity = attribute.Value;
                            }
                            if (attribute.Name == "Display Type")
                            {
                                productBrowse.DisplayType = attribute.Value;
                            }
                            if (attribute.Name == "UnitOfSale")
                            {
                                productBrowse.UnitOfSale = attribute.Value;
                            }
                        }

                        if (productPrice != null)
                        {
                            foreach (var p in productPrice)
                            {
                                foreach (var linePrice in p.LinePrices)
                                {
                                    int index = linePrice.ProductId.IndexOf(":");
                                    string prodId = linePrice.ProductId.Substring(++index, linePrice.ProductId.Length-index);
                                    if (prodId == prod.ProductId.ToString())
                                    {
                                        productBrowse.TotalSellingPrice = linePrice.TotalSellingPrice;
                                        productBrowse.UnitOfMeasure = linePrice.Uom;
                                        productBrowse.UnitSellingPrice = linePrice.UnitSellingPrice.Amount;
                                    }
                                }
                            }
                        }
                        lstProductBrowse.Add(productBrowse);
                    }
                }
            }

            return lstProductBrowse;
        }
    }
}