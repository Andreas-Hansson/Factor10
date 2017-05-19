using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kitchen;
using System.Linq;

namespace KitchenUnitTest
{

    [TestClass]
    public class ReceiptServiceTest
    {
        private const string MeatballsAndPotatoReceipt = "MeatballsAndPotato";
        private const string PancakeReceipt = "Pancake";

        [TestMethod]
        public void AddReceiptPancake()
        {
            var service = new ReceiptService(new FakeFridgeItemRepository(), new FakeReceiptRepository());
            var receipt = new Receipt();
            var pancake = new Receipt { Name = PancakeReceipt };
            var eggItem = new Item
            {
                Name = "Egg",
                Quantity = new Quantity { Unit = "P", Total = 3 }
            };
            var milkItem = new Item
            {
                Name = "Milk",
                Quantity = new Quantity { Unit = "L", Total = new decimal(0.7) }
            };
            var flourItem = new Item
            {
                Name = "Flour",
                Quantity = new Quantity { Unit = "L", Total = new decimal(0.5) }
            };
            pancake.Ingredients.Add(eggItem);
            pancake.Ingredients.Add(milkItem);
            pancake.Ingredients.Add(flourItem);
      
            service.AddRecipt(receipt);

            var result = service.GetReceipt(PancakeReceipt);

            Assert.AreEqual(result.Name, PancakeReceipt);
        }

        [TestMethod]
        public void GetReceiptPancake()
        {
            var service = new ReceiptService(new FakeFridgeItemRepository(), new FakeReceiptRepository());
            var result = service.GetReceipt(PancakeReceipt);

            Assert.AreEqual(result.Name, PancakeReceipt);
        }

        [TestMethod]
        public void DidNotFindReceipt()
        {
            var service = new ReceiptService(new FakeFridgeItemRepository(), new FakeReceiptRepository());
            var result = service.GetReceipt("xxx");

            Assert.IsNull(result);
        }

        [TestMethod]
        public void PossibleToCookPancake()
        {
            var fakeRep = new FakeFridgeItemRepository();

            var flourItem = new FridgeItem
            {
                Name = "Flour",
                Quantity = new Quantity() { Unit = "L", Total = 1 }
            };
            fakeRep.Items.Add(flourItem);
            var eggItem = new FridgeItem
            {
                Name = "Egg",
                Quantity = new Quantity() { Unit = "P", Total = 8 }
            };
            fakeRep.Items.Add(eggItem);
            var milkItem = new FridgeItem
            {
                Name = "Milk",
                Quantity = new Quantity() { Unit = "L", Total = 2 }
            };
            fakeRep.Items.Add(milkItem);



            var worker = new ReceiptService(fakeRep, new FakeReceiptRepository());
            var result =  worker.PossibleToCook(worker.GetReceipt(PancakeReceipt));

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void NotPossibleToCookPancake()
        {
        
            var fakeRep = new FakeFridgeItemRepository();

            var flourItem = new FridgeItem
            {
                Name = "Flour",
                Quantity = new Quantity() { Unit = "L", Total = 1 }
            };
            fakeRep.Items.Add(flourItem);
            var eggItem = new FridgeItem
            {
                Name = "Egg",
                Quantity = new Quantity() { Unit = "P", Total = 1 }
            };
            fakeRep.Items.Add(eggItem);
            var milkItem = new FridgeItem
            {
                Name = "Milk",
                Quantity = new Quantity() { Unit = "L", Total = 2 }
            };
            fakeRep.Items.Add(milkItem);
          
            var worker = new ReceiptService(fakeRep, new FakeReceiptRepository());
            var result = worker.PossibleToCook(worker.GetReceipt(PancakeReceipt));

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetPossibleMealsPancakeAndMeatballs()
        {
            var fakeRep = new FakeFridgeItemRepository();

            var flourItem = new FridgeItem
            {
                Name = "Flour",
                Quantity = new Quantity() { Unit = "L", Total = 1 }
            };
            fakeRep.Items.Add(flourItem);
            var eggItem = new FridgeItem
            {
                Name = "Egg",
                Quantity = new Quantity() { Unit = "P", Total = 8 }
            };
            fakeRep.Items.Add(eggItem);
            var milkItem = new FridgeItem
            {
                Name = "Milk",
                Quantity = new Quantity() { Unit = "L", Total = 2 }
            };
            fakeRep.Items.Add(milkItem);
            var meatItem = new FridgeItem
            {
                Name = "Meat",
                Quantity = new Quantity() { Unit = "KG", Total = 10 }
            };
            fakeRep.Items.Add(meatItem);
            var potatoItem = new FridgeItem
            {
                Name = "Potato",
                Quantity = new Quantity() { Unit = "KG", Total = 15 }
            };
            fakeRep.Items.Add(potatoItem);

            var worker = new ReceiptService(fakeRep, new FakeReceiptRepository());
            var result = worker.GetPossibleMeals();

            Assert.AreEqual(result.Count, 2);
            Assert.IsNotNull(result.FirstOrDefault(x => x.Meal == PancakeReceipt));
            Assert.IsNotNull(result.FirstOrDefault(x => x.Meal == MeatballsAndPotatoReceipt));
            Assert.IsNull(result.FirstOrDefault(x => x.Meal == "xxx"));
        }

        [TestMethod]
        public void GetPossibleMealsPancake()
        {
            var fakeRep = new FakeFridgeItemRepository();

            var flourItem = new FridgeItem
            {
                Name = "Flour",
                Quantity = new Quantity() { Unit = "L", Total = 1 }
            };
            fakeRep.Items.Add(flourItem);
            var eggItem = new FridgeItem
            {
                Name = "Egg",
                Quantity = new Quantity() { Unit = "P", Total = 8 }
            };
            fakeRep.Items.Add(eggItem);
            var milkItem = new FridgeItem
            {
                Name = "Milk",
                Quantity = new Quantity() { Unit = "L", Total = 2 }
            };
            fakeRep.Items.Add(milkItem);
            var meatItem = new FridgeItem
            {
                Name = "Meat",
                Quantity = new Quantity() { Unit = "KG", Total = 10 }
            };
            fakeRep.Items.Add(meatItem);
            var potatoItem = new FridgeItem
            {
                Name = "Potato",
                Quantity = new Quantity() { Unit = "KG", Total = 1 }
            };
            fakeRep.Items.Add(potatoItem);

            var worker = new ReceiptService(fakeRep, new FakeReceiptRepository());
            var result = worker.GetPossibleMeals();

            Assert.AreEqual(result.Count, 1);
            Assert.IsNotNull(result.FirstOrDefault(x => x.Meal == PancakeReceipt));
            Assert.IsNull(result.FirstOrDefault(x => x.Meal == MeatballsAndPotatoReceipt));
        }
    }
}
