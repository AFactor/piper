using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesco.Com.Pipeline.Pipe
{


    public abstract class BaseOperation<T>
    {
        public string[] ParamArray { get; set; }
        public abstract IEnumerable<T> Execute(IEnumerable<T> input);
    }

}
