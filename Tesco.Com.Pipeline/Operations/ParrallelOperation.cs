//using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tesco.Com.Pipeline.Entities.ProductEntities;
using Tesco.Com.Pipeline.Provider;
using System.Threading.Tasks;

namespace Tesco.Com.Pipeline.Operations
{
    public class ParrallelOperation<T> : BaseOperation<T>,IOperation<T>
    {

        public  ParrallelOperation(List<IOperation<T>> ops)
        {
            Operations = ops;

        }


        public List<IOperation<T>> Operations { get; private set; }
        
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