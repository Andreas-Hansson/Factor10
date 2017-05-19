using System.Collections.Generic;
using Kitchen;

namespace KitchenUnitTest
{
    public class FakeFridgeItemRepository: IFridgeProxy
    {
        public FakeFridgeItemRepository()
        {
            Items = new List<FridgeItem>();
        }

        public List<FridgeItem> Items ;
        public List<Receipt> Recerecipes;

        public List<FridgeItem> GetAll()
        {
            return Items;
        }

        public void Add(FridgeItem item)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(FridgeItem item)
        {
            throw new System.NotImplementedException();
        }
    }
}
