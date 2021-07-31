using System.Linq;
using JustJackjon.CheckoutKata.Library;
using JustJackjon.CheckoutKata.Library.Models;
using NUnit.Framework;

namespace JustJackjon.CheckoutKata.UnitTests
{
    public class BasketTests
    {
        private Item[] _testItemCatalogue;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _testItemCatalogue = new Item[]
            {
                new("A", 10m),
                new("B", 15m),
                new("C", 40m),
                new("D", 55m)
            };
        }

        private Item GetTestItemBySku(string sku) => _testItemCatalogue.ToList().Find(x => x.ItemSku == sku);

        [Test]
        public void ShouldAddCorrectItemToBasketWhenItemIsAddedToBasket()
        {
            // Arrange
            var basket = new Basket();
            var testItem = GetTestItemBySku("A");
            var unexpectedItem = GetTestItemBySku("B");

            // Act
            basket.AddItem(testItem);
            var itemsInBasket = basket.GetItems();

            // Assert
            Assert.That(itemsInBasket, Has.Exactly(1).Items);
            Assert.That(itemsInBasket, Does.Contain(testItem));
            Assert.That(itemsInBasket, Does.Not.Contain(unexpectedItem));
        }

        [TestCase(25.00, "A", "B")]
        [TestCase(135.00, "A", "B", "B", "C", "D")]
        public void ShouldCalculateTheTotalCostItemsHaveBeenAddedToTheBasket(decimal expected, params string[] itemSkus)
        {
            // Arrange
            var basket = new Basket();

            // Act
            foreach (var sku in itemSkus)
            {
                var item = GetTestItemBySku(sku);
                basket.AddItem(item);
            }

            var actual = basket.GetTotalCost();

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(40.00, "B", "B", "B")]
        [TestCase(80.00, "B", "B", "B", "B", "B", "B")]
        public void ShouldApplyPromotion3For40WhenOneMultipleOfThreeLotsOfItemBAddedToBasket(decimal expected, params string[] itemSkus)
        {
            // Arrange
            var basket = new Basket();

            // Act
            foreach (var sku in itemSkus)
            {
                var item = GetTestItemBySku(sku);
                basket.AddItem(item);
            }

            var actual = basket.GetTotalCost();

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}