using JustJackjon.CheckoutKata.Library.Interfaces;

namespace JustJackjon.CheckoutKata.Library.Models
{
    public class Item : IItem
    {
        public Item(string itemSku, decimal unitPrice)
        {
            ItemSku = itemSku;
            UnitPrice = unitPrice;
        }

        public string ItemSku { get; }
        public decimal UnitPrice { get; }
    }
}