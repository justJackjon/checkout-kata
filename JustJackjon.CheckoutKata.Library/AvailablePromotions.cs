using System.Collections.Generic;
using JustJackjon.CheckoutKata.Library.Strategies.PromotionalStrategies;

namespace JustJackjon.CheckoutKata.Library
{
    public class AvailablePromotions
    {
        public AvailablePromotions()
        {
            Lookup = new Dictionary<int, IPromotionalStrategy>
            {
                {1234, new ItemB3For40Strategy()}
            };
        }

        public Dictionary<int, IPromotionalStrategy> Lookup { get; }
    }
}