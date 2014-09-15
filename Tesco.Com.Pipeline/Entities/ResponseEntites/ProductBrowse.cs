using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tesco.Com.Pipeline.Entities.ResponseEntites
{
    public class ProductBrowse
    {
        public uint ProductId { get; set; }

        public uint BaseProductId { get; set; }

        public string Title { get; set; }

        public string VariantType { get; set; }

        public string UnitQuantity { get; set; }

        public string DisplayType { get; set; }

        public string UnitOfSale { get; set; }

        public Totalsellingprice TotalSellingPrice { get; set; }

        public string UnitOfMeasure { get; set; }

        public float UnitSellingPrice { get; set; }

        public Media Media { get; set; }
    }

    public class Media
    {
        public List<Image> Images { get; set; }
    }

    public class Image
    {
        public string Url { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
    }
}
