using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    internal class OrderServiceTests
    {
        private Mock<IStorage> _storage;

        [SetUp]
        public void SetUp()
        {
            _storage = new Mock<IStorage>();
        }

        [Test]
        public void PlaceOrder_WhenCalled_StoreTheOrder()
        {
            var service = new OrderService(_storage.Object);

            var order = new Order();
            service.PlaceOrder(order);

            _storage.Verify(s => s.Store(order));
        }


    }
}
