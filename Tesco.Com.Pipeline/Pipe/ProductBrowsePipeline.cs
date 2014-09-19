using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tesco.Com.Pipeline.Entities.ProductEntities;
using Tesco.Com.Pipeline.Operations;
using Tesco.Com.Pipeline.Operations.Product;
using Tesco.Com.Pipeline.Operations.Promotion;
using Tesco.Com.Pipeline.Operations.Price;
using Tesco.Com.Pipeline.Operations.Range;

namespace Tesco.Com.Pipeline.Pipe
{
    public class ProductBrowsePipeline : BasePipeline<ResultETL>
    {
        public ProductBrowsePipeline(string query, string offset, string limit, string orderByFields, string business)
        {
         
            var prodOps=new ProductsByIdsOperation();
            prodOps.ParamArray=new string[] { query, offset, limit, "Productinfo," + orderByFields, business };
            Register(new RangeSearchByChannelOperation(), new string[] { query, offset, limit, orderByFields, business })
            //.Register(new ProductsByIdsOperation() ,new string[] { query, offset, limit, "Productinfo," + orderByFields, business })
            //.Register(new  PriceByIdOperation())
            //.Register(new PromotionSearchOperation());
           .RegisterParrallel(new List<IOpeariton<ResultETL>>() {prodOps, new PriceByIdOperation(), new PromotionSearchOperation() });

        }
    }
}