using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesco.Com.Pipeline.Entities.ProductEntities;
namespace Tesco.Com.Pipeline.Provider.Contract
{
    public interface IPromotionProvider
    {
        List<PromotionObject> Search(string q, string[] fields, int? limit, int? offset);
    }
}
