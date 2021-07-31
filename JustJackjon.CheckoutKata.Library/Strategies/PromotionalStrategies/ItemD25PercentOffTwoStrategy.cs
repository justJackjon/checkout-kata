using System.Collections.Generic;
using JustJackjon.CheckoutKata.Library.Models;

namespace JustJackjon.CheckoutKata.Library.Strategies.PromotionalStrategies
{
    public class ItemD25PercentOffTwoStrategy : IPromotionalStrategy
    {
        public decimal ApplyPromotion(List<PromotionalItem> qualifyingItems, decimal subTotal)
        {
            // TODO: Implement proper solution. WIP commit to satisfy initial red / green TDD stage.
            if (qualifyingItems.Count >= 2)
            {
                return subTotal * 0.75m;
            }

            return subTotal;
        }
    }
}