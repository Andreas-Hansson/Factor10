using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order;

namespace OrderUnitTest
{
    [TestClass]
    public class OrderServiceTest
    {
        [TestMethod]
        public void GetAvailableMeals()
        {
            var service = new OrderService(null);
            var result =  service.GetAvailableMeals();
            Assert.AreEqual(result[0].Meal, "Pancace");
        }
    }
}
