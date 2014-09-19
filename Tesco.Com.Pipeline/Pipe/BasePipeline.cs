using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tesco.Com.Pipeline.Utilities;
using Tesco.Com.Pipeline.Operations;
namespace Tesco.Com.Pipeline.Pipe
{
    public class BasePipeline<T>:IPipeline<T>
    {
        private readonly List<IOpeariton<T>> _operations = new List<IOpeariton<T>>();


        public BasePipeline<T> Register(IOpeariton<T> operation, string[] paramArray)
        {

            operation.ParamArray = paramArray;
            return Register(operation);

        }

        public BasePipeline<T> Register(IOpeariton<T> operation)
        {

            _operations.Add(operation);
            Logger.Info(operation.ToString() + " added");
            return this;
        }

        public BasePipeline<T> RegisterParrallel(List<IOpeariton<T>> operations)
        {
            _operations.Add(new ParrallelOperation<T>(operations));
            Logger.Info(
                string.Join(",",operations.Select(o=>o.ToString())) + " added as parrallel steps"
            );
            return this;
        }

        public IEnumerable<T> Execute()
        {
            Logger.Info("pipeline has started execution");

            IEnumerable<T> result = new List<T>();


            foreach (BaseOperation<T> operation in _operations)
            {
                Logger.Info(operation.ToString() + " will start execution");
                result = operation.Execute(result);
                Logger.Info(operation.ToString() + " executed");
            }
            //IEnumerator<T> enumerator = Current.GetEnumerator();
            //while (enumerator.MoveNext()) ;
            return result;

        }
    }
}


