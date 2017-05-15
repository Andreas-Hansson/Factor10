using System.Collections.Generic;

namespace Kitchen
{
    public class ReceiptRepository:IReceiptRepository
    {

        public static string PancakeReceipt = "Pancake";
        public static string MeatballsAndPotatoRecept = "MeatballsAndPotato";
        
        public List<Receipt> GetAllReceipts()
        {
            var receipts = new List<Receipt>();
            var pancake = new Receipt() {Name = PancakeReceipt };
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


            receipts.Add(pancake);

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
            receipts.Add(meatballsAnPotato);

            return receipts;
        }



    }
}
