namespace JustJackjon.CheckoutKata.Library.Interfaces
{
    public interface IItem
    {
        public string ItemSku { get; }

        public decimal UnitPrice { get; }
    }
}