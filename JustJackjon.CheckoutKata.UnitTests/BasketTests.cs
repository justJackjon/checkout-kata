using System.Linq;
using JustJackjon.CheckoutKata.Library;
using JustJackjon.CheckoutKata.Library.Interfaces;
using JustJackjon.CheckoutKata.Library.Models;
using NUnit.Framework;

namespace JustJackjon.CheckoutKata.UnitTests
{
    public class BasketTests
    {
        private IItem[] _testItemCatalogue;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _testItemCatalogue = new IItem[]
            {
                new Item("A", 10m),
                new PromotionalItem("B", 15m, 1234),
                new Item("C", 40m),
                new PromotionalItem("D", 55m, 5678)
            };
        }

        private IItem GetTestItemBySku(string sku) => _testItemCatalogue.ToList().Find(x => x.ItemSku == sku);

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
        [TestCase(105.00, "A", "B", "C", "B", "B", "B")]
        [TestCase(120.00, "A", "B", "C", "B", "B", "B", "B")]
        [TestCase(240.00, "A", "B", "C", "D", "B", "B", "B", "B", "B", "B", "B", "B", "B")]
        public void ShouldApplyPromotion3For40WhenMultiplesOfThreeLotsOfItemBAddedToBasket(decimal expected,
            params string[] itemSkus)
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

        [Test]
        public void ShouldApplyPromotion25PercentOffEveryTwoWhenMultipliesOfTwoOfItemDAddedToBasket()
        {
            // Arrange
            const decimal expected = 82.5m;
            string[] itemSkus = {"D", "D"};
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