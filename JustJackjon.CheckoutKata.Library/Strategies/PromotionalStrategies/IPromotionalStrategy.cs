using System.Collections.Generic;
using JustJackjon.CheckoutKata.Library.Models;

namespace JustJackjon.CheckoutKata.Library.Strategies.PromotionalStrategies
{
    public interface IPromotionalStrategy
    {
        decimal ApplyPromotion(List<PromotionalItem> promotionalItems, decimal subTotal);
    }
}