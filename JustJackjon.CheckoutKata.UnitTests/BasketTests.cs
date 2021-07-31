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
            var unexpectedItem = new Item("B", 15m);

            // Act
            basket.AddItem(testItem);
            var itemsInBasket = basket.GetItems();

            // Assert
            Assert.That(itemsInBasket, Has.Exactly(1).Items);
            Assert.That(itemsInBasket, Does.Contain(testItem));
            Assert.That(itemsInBasket, Does.Not.Contain(unexpectedItem));
        }

        [Test]
        public void ShouldCalculateTheTotalCostWhenTwoItemsHaveBeenAddedToTheBasket()
        {
            // Arrange
            const decimal expected = 25m;
            var basket = new Basket();
            Item[] testItems = {new("A", 10m), new("B", 15m)};

            // Act
            foreach (var item in testItems)
            {
                basket.AddItem(item);
            }

            var actual = basket.GetTotalCost();

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldCalculateTheTotalCostWhenMultipleItemsHaveBeenAddedToTheBasket()
        {
            // Arrange
            const decimal expected = 135m;
            var basket = new Basket();
            Item[] testItems =
            {
                new("A", 10m),
                new("B", 15m),
                new("B", 15m),
                new("C", 40m),
                new("D", 55m)
            };

            // Act
            foreach (var item in testItems)
            {
                basket.AddItem(item);
            }

            var actual = basket.GetTotalCost();

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}