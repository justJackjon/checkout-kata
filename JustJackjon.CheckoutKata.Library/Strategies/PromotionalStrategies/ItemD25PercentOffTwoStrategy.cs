using System.Collections.Generic;
using System.Linq;
using JustJackjon.CheckoutKata.Library.Models;

namespace JustJackjon.CheckoutKata.Library.Strategies.PromotionalStrategies
{
    public class ItemD25PercentOffTwoStrategy : IPromotionalStrategy
    {
        public decimal ApplyPromotion(List<PromotionalItem> qualifyingItems, decimal subTotal)
        {
            const int numItemsToTriggerPromo = 2;
            var returnTotal = subTotal;

            if (qualifyingItems.Count >= numItemsToTriggerPromo)
            {
                var promotionValue = qualifyingItems.First().UnitPrice * 0.25m;
                var numTimesToApplyPromotion = qualifyingItems.Count;
                returnTotal -= (numTimesToApplyPromotion * promotionValue);
            }

            return returnTotal;
        }
    }
}