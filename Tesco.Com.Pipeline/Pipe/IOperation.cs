using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesco.Com.Pipeline.Pipe
{
    public interface IOperation<T>
    {
        IEnumerable<T> Execute(IEnumerable<T> input);
    }
}
