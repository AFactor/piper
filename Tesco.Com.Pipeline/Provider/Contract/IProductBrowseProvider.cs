using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tesco.Com.Pipeline.Provider.Contract
{
    public interface IProductBrowseProvider
    {
        List<Entities.ResponseEntites.ProductBrowse> GetProductList(string query, string offset, string limit, string orderByFields, string business);
    }
}
