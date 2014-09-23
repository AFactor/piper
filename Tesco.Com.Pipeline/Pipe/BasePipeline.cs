using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tesco.Com.Pipeline.Utilities;
using Tesco.Com.Pipeline.Operations;

namespace Tesco.Com.Pipeline.Pipe
{
    public abstract class BasePipeline<T> : IPipeline<T>
    {
        private readonly List<IOperation<T>> _operations = new List<IOperation<T>>();

        public virtual BasePipeline<T> Register(IOperation<T> operation, string[] paramArray)
        {
            operation.ParamArray = paramArray;
            return Register(operation);
        }

        public virtual BasePipeline<T> Register(string[] paramArray)
        {
            throw new NotImplementedException("Do not use this method in the base");
        }

        public BasePipeline<T> Register(IOperation<T> operation)
        {
            _operations.Add(operation);
            Logger.Info(operation.ToString() + " added");
            return this;
        }

        public BasePipeline<T> RegisterParrallel(List<IOperation<T>> operations)
        {
            _operations.Add(new ParrallelOperation<T>(operations));
            Logger.Info(
                string.Join(",",operations.Select(o=>o.ToString())) + " added as parallel steps"
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


