using System.Collections.Generic;
using Kitchen;
using IItemRepository = Fridge.IItemRepository;
using Item = Fridge.Item;

namespace KitchenUnitTest
{
    public class FakeFridgeItemRepository:IItemRepository
    {
        public FakeFridgeItemRepository()
        {
            Items = new List<Item>();
        }

        public List<Item> Items ;
        public List<Receipt> Recerecipes;

        public List<Item> GetAll()
        {
            return Items;
        }

        public void Add(Item item)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Item item)
        {
            throw new System.NotImplementedException();
        }
    }
}
