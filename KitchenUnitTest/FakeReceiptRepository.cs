using System;
using System.Collections.Generic;
using System.Text;
using Kitchen;

namespace KitchenUnitTest
{
    public class FakeReceiptRepository:IReceiptRepository
    {

        public static string PancakeReceipt = "Pancake";
        public static string MeatballsAndPotatoRecept = "MeatballsAndPotato";

        public List<Receipt> Receipts;

        public FakeReceiptRepository()
        {
            Receipts = new List<Receipt>();
        }
        public List<Receipt> GetAllReceipts()
        {
            
            var pancake = new Receipt() { Name = PancakeReceipt };
            var eggItem = new Item
            {
                Name = "Egg",
                Quantity = new Quantity() { Unit = "P", Total = 3 }
            };
            var milkItem = new Item
            {
                Name = "Milk",
                Quantity = new Quantity() { Unit = "L", Total = new decimal(0.7) }
            };
            var flourItem = new Item
            {
                Name = "Flour",
                Quantity = new Quantity() { Unit = "L", Total = new decimal(0.5) }
            };
            pancake.Ingredients.Add(eggItem);
            pancake.Ingredients.Add(milkItem);
            pancake.Ingredients.Add(flourItem);


            Receipts.Add(pancake);

            var meatballsAnPotato = new Receipt() { Name = MeatballsAndPotatoRecept };
            var meatItem = new Item
            {
                Name = "Meat",
                Quantity = new Quantity() { Unit = "KG", Total = 1 }
            };
            var potatoItem = new Item
            {
                Name = "Potato",
                Quantity = new Quantity() { Unit = "KG", Total = 2 }
            };
            meatballsAnPotato.Ingredients.Add(meatItem);
            meatballsAnPotato.Ingredients.Add(potatoItem);
            Receipts.Add(meatballsAnPotato);

            return Receipts;
        }

        public void Add(Receipt receipt)
        {
            Receipts.Add(receipt);
        }
    }
}
