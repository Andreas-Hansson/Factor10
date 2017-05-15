using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Fridge
{
    
    public class ItemRepository: IItemRepository
    {
        private readonly List<Item> _items;

        public ItemRepository()
        {
            _items = new List<Item>();
        }

        public List<Item> GetAll()
        {
            return _items;
        }

        public void Add(Item item)
        {
            var currentItem = Get(item.Name);
            if(currentItem == null)
                _items.Add(item);
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
            return _items.FirstOrDefault(x => x.Name == name);
        }

    }
}
