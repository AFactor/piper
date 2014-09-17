using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesco.Com.Pipeline.Entities.ProductEntities;
namespace Tesco.Com.Pipeline.Provider.Contract
{
    public interface IPriceProvider
    {
        PriceResult CalculateTotal(List<string> productIds,  string zone, DateTime? validFrom, DateTime? validTill, string applicablePromotionTypes);
    }
}
