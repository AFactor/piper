using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductAPI.Entities.ProductEntities;
namespace ProductAPI.Provider.Contract
{
    public interface IPromotionProvider
    {
        List<PromotionObject> Search(string q, string[] fields, int? limit, int? offset);
    }
}
