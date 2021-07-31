namespace JustJackjon.CheckoutKata.Library.Models
{
    public class Item
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