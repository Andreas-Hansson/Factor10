using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Fridge;

namespace FridgeUnitTest
{
    public class FakeItemRepository : IItemRepository 
    {
        public FakeItemRepository()
        {
            Items = new List<Item>();
        }

        public List<Item> Items;
        public List<Item> GetAll()
        {
            return Items;
        }

        public void Add(Item item)
        {
            var currentItem = Get(item.Name);
            if (currentItem == null)
                Items.Add(item);
            else
                currentItem.Quantity.Total += item.Quantity.Total;
        }

        public void Remove(Item item)
        {
            var currentItem = Get(item.Name);
            if (currentItem != null)
                currentItem.Quantity.Total -= item.Quantity.Total;
        }


        private Item Get(string name)
        {
            return Items.FirstOrDefault(x => x.Name == name);
        }
    }
}
