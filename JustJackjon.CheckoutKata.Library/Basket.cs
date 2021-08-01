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

        private static decimal ApplyPromotionStrategies(IEnumerable<PromotionalItem> promotionalItems, decimal subTotal)
        {
            var itemsToProcess = promotionalItems.ToList();
            var runningTotal = subTotal;

            while (itemsToProcess.Count > 0)
            {
                var currentPromoId = itemsToProcess.First().PromoId;
                var qualifyingItems = itemsToProcess.FindAll(x => x.PromoId == currentPromoId);
                var strategy = new AvailablePromotionsFactory().Lookup[currentPromoId];

                runningTotal = strategy.ApplyPromotion(qualifyingItems, runningTotal);
                itemsToProcess.RemoveAll(x => x.PromoId == currentPromoId);
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