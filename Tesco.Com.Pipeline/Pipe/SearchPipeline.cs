using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tesco.Com.Pipeline.Entities.ProductEntities;
using Tesco.Com.Pipeline.Operations;
using Tesco.Com.Pipeline.Operations.Product;
using Tesco.Com.Pipeline.Operations.Promotion;
using Tesco.Com.Pipeline.Operations.Price;
namespace Tesco.Com.Pipeline.Pipe
{
    public class SearchPipeline : BasePipeline<ResultETL>
    {

        
        
        public SearchPipeline(string queryText, string pageNumber, string sort, string perPage)
        {
            Register(new ProductSearchOperation(), new string[] { queryText, sort, pageNumber, perPage })
           .RegisterParrallel(new List<IOperation<ResultETL>>() {new PriceByIdOperation(),new PromotionSearchOperation()});

        }

       
    }
}