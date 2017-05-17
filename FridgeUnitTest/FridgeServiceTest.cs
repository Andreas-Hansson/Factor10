using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fridge;

namespace FridgeUnitTest
{
    [TestClass]
    public class FridgeServiceTest
    {
        [TestMethod]
        public void ItemExistInFridge()
        {
            var repository = new FakeItemRepository();
            repository.Items.Add(new Item() { Name = "Egg" });

            var worker = new FridgeService(repository);
            var result = worker.IsAvailable("Egg");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ItemNotExistInFridge()
        {
            var repository = new FakeItemRepository();
            repository.Items.Add(new Item() { Name = "Flour" });

            var worker = new FridgeService(repository);
            var result = worker.IsAvailable("Egg");

            Assert.IsFalse(result);
        }


        [TestMethod]
        public void AddItemInFridge()
        {
            var repository = new FakeItemRepository();
            var flourItem = new Item
            {
                Name = "Flour",
                Quantity = new Quantity() { Unit = "L", Total = 1}
            };
            repository.Items.Add(flourItem);

            var worker = new FridgeService(repository);

            var eggItem = new Item
            {
                Name = "Egg",
                Quantity = new Quantity() { Unit = "P", Total = 8 }
            };

            var result = worker.AddItem(eggItem);

            Assert.AreEqual(result.Unit, "P");
            Assert.AreEqual(result.Total, 8);
        }


        [TestMethod]
        public void UpdateItemInFridge()
        {
            var repository = new FakeItemRepository();
            var flourItem = new Item
            {
                Name = "Egg",
                Quantity = new Quantity() { Unit = "P", Total = 8 }
            };
            repository.Items.Add(flourItem);

            var worker = new FridgeService(repository);

            var eggItem = new Item
            {
                Name = "Egg",
                Quantity = new Quantity() { Unit = "P", Total = 8 }
            };

            var result = worker.AddItem(eggItem);

            Assert.AreEqual(result.Unit, "P");
            Assert.AreEqual(result.Total, 16);
        }

        [TestMethod]
        public void RemoveItemInFridge()
        {
            var repository = new FakeItemRepository();
            var flourItem = new Item
            {
                Name = "Flour",
                Quantity = new Quantity() { Unit = "L", Total = 1 }
            };
            repository.Items.Add(flourItem);
            var eggItem = new Item
            {
                Name = "Egg",
                Quantity = new Quantity() { Unit = "P", Total = 8 }
            };
            repository.Items.Add(eggItem);

            var worker = new FridgeService(repository);
            var eggsToRemove = new Item
            {
                Name = "Egg",
                Quantity = new Quantity() { Unit = "P", Total = 3 }
            };

            var result = worker.RemoveItem(eggsToRemove);

            Assert.AreEqual(result.Total, 5);
        }


    }
}
