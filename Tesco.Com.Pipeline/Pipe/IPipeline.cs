using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesco.Com.Pipeline.Operations;

namespace Tesco.Com.Pipeline.Pipe
{
    public interface IPipeline<T>
    {
        BasePipeline<T> Register(IOperation<T> operation, string[] paramArray);

        /// <summary>
        /// method to use from controller
        /// </summary>
        /// <param name="paramArray"></param>
        /// <returns></returns>

        BasePipeline<T> Register(string[] paramArray);

        BasePipeline<T> Register(IOperation<T> operation);

        BasePipeline<T> RegisterParrallel(List<IOperation<T>> operations);
        
        IEnumerable<T> Execute();

        //IEnumerable<T> Initialize(string[] args);
    }
}
