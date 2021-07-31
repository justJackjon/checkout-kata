using System.Collections.Generic;
using JustJackjon.CheckoutKata.Library.Models;

namespace JustJackjon.CheckoutKata.Library.Strategies.PromotionalStrategies
{
    public class ItemB3For40Strategy : IPromotionalStrategy
    {
        public decimal ApplyPromotion(List<PromotionalItem> promotionalItems, decimal subTotal)
        {
            const int numItemsToTriggerPromo = 3;
            var returnTotal = subTotal;

            if (promotionalItems.Count >= numItemsToTriggerPromo)
            {
                const decimal promotionValue = 5m;
                var numTimesToApplyPromotion = promotionalItems.Count / numItemsToTriggerPromo;
                returnTotal -= (numTimesToApplyPromotion * promotionValue);
            }

            return returnTotal;
        }
    }
}