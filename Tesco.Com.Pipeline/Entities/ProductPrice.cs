using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tesco.Com.Pipeline.Entities
{
    public class PriceResult
    {
        //public DateTime ValidFrom { get; set; }
        //public DateTime ValidTill { get; set; }
        public string Pricetype { get; set; }
        public Lineprice[] LinePrices { get; set; }
    }

    public class Lineprice
    {
        public string ProductId { get; set; }
        public string Uom { get; set; }
        public float Quantity { get; set; }
        public Unitsellingprice UnitSellingPrice { get; set; }
        public Totalsellingprice TotalSellingPrice { get; set; }
    }

    public class Unitsellingprice
    {
        public float Amount { get; set; }
    }

    public class Totalsellingprice
    {
        public float Amount { get; set; }
    }

}