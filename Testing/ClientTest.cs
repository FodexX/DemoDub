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
            Client client = new Client { Discount = 10 }; // 10% ������
            decimal originalPrice = 100m;
            decimal expectedPrice = 90m; // ��������� ���� ����� ������ 10%

            decimal actualPrice = client.CalculateDiscountedPrice(originalPrice);

            Assert.AreEqual(expectedPrice, actualPrice, "���� �� ������� ���������� �������.");
        }

        [TestMethod]
        public void CalculateDiscountedPrice_WithZeroDiscount_ReturnsOriginalPrice()
        {
            Client client = new Client { Discount = 0 }; // 0% ������
            decimal originalPrice = 100m;
            decimal expectedPrice = 100m;

            decimal actualPrice = client.CalculateDiscountedPrice(originalPrice);

            Assert.AreEqual(expectedPrice, actualPrice, "���� �� ������� ������ ���� ����� ����������� ���� ��� ������ 0%.");
        }

        [TestMethod]
        public void CalculateDiscountedPrice_WithFullDiscount_ReturnsZero()
        {
            Client client = new Client { Discount = 100 }; // 100% ������
            decimal originalPrice = 100m;
            decimal expectedPrice = 0m;

            decimal actualPrice = client.CalculateDiscountedPrice(originalPrice);

            Assert.AreEqual(expectedPrice, actualPrice, "���� �� ������� ������ ���� ����� ���� ��� ������ 100%.");
        }
    }
}
