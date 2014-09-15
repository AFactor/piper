using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tesco.Com.Pipeline.Entities.RequestEntities
{
    public class Products
    {
        public Arrayoflineitem ArrayOfLineItem { get; set; }
    }

    public class Arrayoflineitem
    {
        public List<Lineitem> LineItem { get; set; }
    }

    public class Lineitem
    {
        public string ProductId { get; set; }
    }
}