using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesco.Com.Pipeline.Entities.ProductEntities;
namespace Tesco.Com.Pipeline.Provider.Contract
{
    public interface IProductProvider
    {
        ProductResult Search(string q, string[] fields, string orderByFields, int? offset, int? limit );
    }
}
