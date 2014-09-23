using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tesco.Com.Pipeline.Provider.Contract
{
    public interface IProductBrowseProvider
    {
        List<Entities.ResponseEntities.ProductBrowse> GetProductList(string query, string offset, string limit, string orderByFields, string business);
    }
}
