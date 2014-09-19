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
        BasePipeline<T> Register(IOpeariton<T> operation, string[] paramArray);

        BasePipeline<T> Register(IOpeariton<T> operation);

        BasePipeline<T> RegisterParrallel(List<IOpeariton<T>> operations);
        
        IEnumerable<T> Execute();
        
    }
}
