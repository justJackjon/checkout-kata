using JustJackjon.CheckoutKata.Library.Interfaces;

namespace JustJackjon.CheckoutKata.Library.Models
{
    public class PromotionalItem : IItem, IPromotional
    {
        public PromotionalItem(string itemSku, decimal unitPrice, int promoId)
        {
            ItemSku = itemSku;
            UnitPrice = unitPrice;
            PromoId = promoId;
        }

        public string ItemSku { get; }
        public decimal UnitPrice { get; }
        public int PromoId { get; }
    }
}