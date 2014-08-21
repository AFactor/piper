using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tesco.Com.Pipeline.Pipe
{
    public class BasePipeline<T>
    {
        private readonly List<IOperation<T>> operations = new List<IOperation<T>>();

        public BasePipeline<T> Register(IOperation<T> operation)
        {
            operations.Add(operation);
            return this;
        }

        public void Execute()
        {
            IEnumerable<T> current = new List<T>();
            foreach (IOperation<T> operation in operations)
            {
                current = operation.Execute(current);
            }
            IEnumerator<T> enumerator = current.GetEnumerator();
            while (enumerator.MoveNext()) ;
        }
    }
}


