using DemoLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void CalculateDiscountedPrice_WithValidDiscount_ReturnsCorrectPrice()
        {
            Client client = new Client { Discount = 10 }; // 10% скидка
            decimal originalPrice = 100m;
            decimal expectedPrice = 90m; // Ожидаемая цена после скидки 10%

            decimal actualPrice = client.CalculateDiscountedPrice(originalPrice);

            Assert.AreEqual(expectedPrice, actualPrice, "Цена со скидкой рассчитана неверно.");
        }

        [TestMethod]
        public void CalculateDiscountedPrice_WithZeroDiscount_ReturnsOriginalPrice()
        {
            Client client = new Client { Discount = 0 }; // 0% скидка
            decimal originalPrice = 100m;
            decimal expectedPrice = 100m;

            decimal actualPrice = client.CalculateDiscountedPrice(originalPrice);

            Assert.AreEqual(expectedPrice, actualPrice, "Цена со скидкой должна быть равна изначальной цене при скидке 0%.");
        }

        [TestMethod]
        public void CalculateDiscountedPrice_WithFullDiscount_ReturnsZero()
        {
            Client client = new Client { Discount = 100 }; // 100% скидка
            decimal originalPrice = 100m;
            decimal expectedPrice = 0m;

            decimal actualPrice = client.CalculateDiscountedPrice(originalPrice);

            Assert.AreEqual(expectedPrice, actualPrice, "Цена со скидкой должна быть равна нулю при скидке 100%.");
        }
    }
}
