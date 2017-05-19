using System;
using Kitchen;
using KitchenUnitTest;
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
            var fakeFridgeItemRepository = new FakeFridgeItemRepository();

            var flourItem = new FridgeItem
            {
                Name = "Flour",
                Quantity = new Quantity() { Unit = "L", Total = 1 }
            };
            fakeFridgeItemRepository.Items.Add(flourItem);
            var eggItem = new FridgeItem
            {
                Name = "Egg",
                Quantity = new Quantity() { Unit = "P", Total = 8 }
            };
            fakeFridgeItemRepository.Items.Add(eggItem);
            var milkItem = new FridgeItem
            {
                Name = "Milk",
                Quantity = new Quantity() { Unit = "L", Total = 2 }
            };
            fakeFridgeItemRepository.Items.Add(milkItem);
            var fakeReceitRepostory = new FakeReceiptRepository();
            var service = new OrderService(fakeFridgeItemRepository, fakeReceitRepostory);
            var result =  service.GetAvailableMeals();
            Assert.AreEqual(result[0].Meal, "Pancake");
        }
    }
}
