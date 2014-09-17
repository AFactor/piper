using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tesco.Com.Pipeline.Entities.Range
{

    //public class RangeChannelSearch
    //{
    //    [JsonProperty("Resultsubset")]
    //    public RangedProduct[] RangedProducts { get; set; }
    //    public int TotalMatchedCount { get; set; }
    //}


    //public class RangedProduct
    //{
    //    public string ProductId { get; set; }
    //    public string HierarchyPath { get; set; }
    //}




    public class RangeChannelSearch
    {
        public Resultsubset[] ResultSubSet { get; set; }
        public int TotalMatchedCount { get; set; }
    }

    public class Resultsubset
    {
        public string ProductId { get; set; }
        public string HierarchyPath { get; set; }
    }

}