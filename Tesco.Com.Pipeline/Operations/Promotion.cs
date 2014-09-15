//using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tesco.Com.Pipeline.Entities.ProductEntities;
using Tesco.Com.Pipeline.Provider;
using Tesco.Com.Pipeline.Operations;
namespace Tesco.Com.Pipeline.Operations.Promotion
{
    public class PromotionSearchOperation : ApiOperation<ResultETL>
    {


       

        public override IEnumerable<ResultETL> Execute(IEnumerable<ResultETL> input)
        {

            var ids = "productIds:" + string.Join(",", input.Select(m => m.ProductId));
            //limit and offset doesn't matter, will be determined by product
            ParamArray = new string[] { ids, "0", "1000" };
                
            var result = (List<PromotionObject>)FromApi("PromotionByProductIds", string.Empty, ParamArray);

            //simplify the promo-product id relation. ProductId is hidden down the level. BAD.
            foreach (PromotionObject p in result)
            {
                var pId = p.Buckets.FirstOrDefault().Attachments.FirstOrDefault(a => (a.Type == "productid")).Value;
                p.ProductId = pId;
            }
            
            foreach (ResultETL resultDetail in input)
            {
                if (result.FirstOrDefault(pr => pr.ProductId.Contains(resultDetail.ProductId)) != null)
                {
                    var promo = result.FirstOrDefault(pr => pr.ProductId.Contains(resultDetail.ProductId));
                    resultDetail.PromoId = promo.Id;
                    resultDetail.PromoThreshold = promo.Threshold;
                    resultDetail.PromoDescription = promo.Description;
                    resultDetail.PromoStartDate = promo.StartDate;
                    resultDetail.PromoEndDate = promo.EndDate;
                    resultDetail.PromoType = promo.RewardType;
                }
            }
            return input;
            

        }
    }


   


}