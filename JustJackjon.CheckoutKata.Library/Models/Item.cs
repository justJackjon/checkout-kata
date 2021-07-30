namespace JustJackjon.CheckoutKata.Library.Models
{
    public class Item
    {
        public Item(string itemSku, decimal unitPrice)
        {
            ItemSku = itemSku;
            UnitPrice = unitPrice;
        }

        private string ItemSku { get; }
        private decimal UnitPrice { get; }
    }
}