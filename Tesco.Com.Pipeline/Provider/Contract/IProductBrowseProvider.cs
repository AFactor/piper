using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tesco.Com.Pipeline.Provider.Contract
{
    public interface IProductBrowseProvider
    {
        Entities.ProductList GetProductList(string query, string offset, string limit, string orderByFields, string business);
    }
}
