using System.Collections.Generic;
using System.Linq;
using JustJackjon.CheckoutKata.Library.Interfaces;
using JustJackjon.CheckoutKata.Library.Models;

namespace JustJackjon.CheckoutKata.Library
{
    public class Basket
    {
        private readonly List<IItem> _basketItems;

        public Basket() => _basketItems = new List<IItem>();

        public void AddItem(IItem item) => _basketItems.Add(item);

        public List<IItem> GetItems() => _basketItems;

        private decimal ApplyPromotionStrategies(List<PromotionalItem> promotionalItems, decimal subTotal)
        {
            var promoItemsToProcess = promotionalItems.ToList();
            var runningTotal = subTotal;

            while (promoItemsToProcess.Count > 0)
            {
                var currentPromoId = promoItemsToProcess.First().PromoId;
                var strategy = new AvailablePromotions().Lookup[currentPromoId];

                runningTotal = strategy.ApplyPromotion(promoItemsToProcess, runningTotal);
                promoItemsToProcess.RemoveAll(x => x.PromoId == currentPromoId);
            }

            return runningTotal;
        }

        public decimal GetTotalCost()
        {
            var subTotal = _basketItems.Sum(x => x.UnitPrice);
            var promotionalItems = _basketItems.OfType<PromotionalItem>().ToList();

            if (promotionalItems.Any())
            {
                subTotal = ApplyPromotionStrategies(promotionalItems, subTotal);
            }

            return subTotal;
        }
    }
}