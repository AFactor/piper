using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tesco.Com.Pipeline.Entities.ProductEntities;
namespace Tesco.Com.Pipeline.Pipe
{
    public class SearchPipeline : BasePipeline<ResultETL>
    {

        public SearchPipeline(string queryText, string pageNumber, string sort, string perPage)
        {
            Register(new ProductSearchOperation(), new string[] { queryText, sort, pageNumber, perPage });
            Register(new PriceOperation(), null);
            //Register(new TerminateOperation());

            Execute();

        }
    }
}