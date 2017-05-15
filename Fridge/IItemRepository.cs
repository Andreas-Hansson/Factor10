using System;
using System.Collections.Generic;
using System.Text;

namespace Fridge
{
    public interface IItemRepository
    {
        List<Item> GetAll();

        void Add(Item item);

        void Remove(Item item);
    }
}
