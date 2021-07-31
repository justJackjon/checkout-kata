using System.Collections.Generic;
using System.Linq;
using JustJackjon.CheckoutKata.Library.Models;

namespace JustJackjon.CheckoutKata.Library
{
    public class Basket
    {
        private readonly List<Item> _basketItems;

        public Basket() => _basketItems = new List<Item>();

        public void AddItem(Item item) => _basketItems.Add(item);

        public List<Item> GetItems() => _basketItems;

        public decimal GetTotalCost() => _basketItems.Sum(x => x.UnitPrice);
    }
}