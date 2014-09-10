using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tesco.Com.Pipeline.Utilities;

namespace Tesco.Com.Pipeline.Pipe
{
    public class BasePipeline<T>
    {
        private readonly List<BaseOperation<T>> operations = new List<BaseOperation<T>>();


        public BasePipeline<T> Register(BaseOperation<T> operation, string[] paramArray)
        {

            operation.ParamArray = paramArray;
            return Register(operation);

        }
        public BasePipeline<T> Register(BaseOperation<T> operation)
        {

            operations.Add(operation);
            Logger.Info(operation.ToString() + " added");
            return this;
        }

        public IEnumerable<T> Execute()
        {
            Logger.Info("pipeline has started execution");

            IEnumerable<T> result = new List<T>();


            foreach (BaseOperation<T> operation in operations)
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


