//using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tesco.Com.Pipeline.Entities.ProductEntities;
using Tesco.Com.Pipeline.Provider;
using System.Threading.Tasks;

namespace Tesco.Com.Pipeline.Operations
{
    public class ParrallelOperation<T> : BaseOperation<T>,IOpeariton<T>
    {

        public  ParrallelOperation(List<IOpeariton<T>> ops)
        {
            Operations = ops;

        }


        public List<IOpeariton<T>> Operations { get; private set; }
        
        public override IEnumerable<T> Execute(IEnumerable<T> input)
        {


            Parallel.ForEach (Operations, ops =>
                {
                    input = ops.Execute(input);
                });

           

            return input;

        }
    }


    


}