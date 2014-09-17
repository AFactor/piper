//using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tesco.Com.Pipeline.Entities.ProductEntities;
using Tesco.Com.Pipeline.Provider;
using Tesco.Com.Pipeline.Operations;
namespace Tesco.Com.Pipeline.Operations.Range
{
    public class RangeSearchByChannelOperation : ApiOperation<ResultETL>
    {
        public override IEnumerable<ResultETL> Execute(IEnumerable<ResultETL> input)
        {
            var result = (Entities.Range.RangeChannelSearch)FromApi("AnonymousProductBrowseRangeSearch", string.Empty, ParamArray);
            List<ResultETL> products = new List<ResultETL>();
            foreach (Entities.Range.Resultsubset prod in result.ResultSubSet)
            {
                var product = new ResultETL();
                product.ProductId = prod.ProductId;
                products.Add(product);
            }
            return products;

        }
    }
}