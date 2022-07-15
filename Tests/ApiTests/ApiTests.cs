using ApiFramework;
using NUnit.Framework;
using System;
using Util;

namespace Tests.ApiTests
{
    [Parallelizable]
    [TestFixture]
    public class ApiTests : TestBase
    {
        Client client;

        [OneTimeSetUp]
        public void ClassInit()
        {
            client = new Client(System);
        }

        [Test]
        public void GetEnergy()
        {
            var energy = client.ApiController.GetEnergy();
        }

        [Test]
        public void GetOrders()
        {
            var orders = client.ApiController.GetOrders();
        }

        [TestCase(EnergyType.Electric, 10)]
        [TestCase(EnergyType.Gas, 4)]
        [TestCase(EnergyType.Oil, 15)]
        [TestCase(EnergyType.Nuclear, 22)]
        public void BuyEnergy(EnergyType energyType, int value)
        {
            var availablity = client.ApiController.GetEnergy(energyType).Quantity >= value;

            var buy = client.ApiController.Buy(energyType, value);

            var order = client.ApiController.GetOrder(buy.OrderId);

            if (availablity)
            {
                Assert.AreEqual(value, order.Quantity);
                Assert.AreEqual(DateTime.Today.ToString("yyyy-MM-dd"), order.Time.ToString("yyyy-MM-dd"));
            }
            else Assert.IsNull(order, $"Order was successfully placed for {energyType} whilst no units were available");
        }

    }
}
