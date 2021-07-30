using JustJackjon.CheckoutKata.Library;
using JustJackjon.CheckoutKata.Library.Models;
using NUnit.Framework;

namespace JustJackjon.CheckoutKata.UnitTests
{
    public class BasketTests
    {
        [Test]
        public void ShouldAddCorrectItemToBasketWhenItemIsAddedToBasket()
        {
            // Arrange
            var basket = new Basket();
            var testItem = new Item("A", 10m);

            // Act
            basket.AddItem(testItem);
            var itemsInBasket = basket.GetItems();

            // Assert
            Assert.That(itemsInBasket, Has.Exactly(1).Items);
            Assert.That(itemsInBasket, Does.Contain(testItem));
        }
    }
}