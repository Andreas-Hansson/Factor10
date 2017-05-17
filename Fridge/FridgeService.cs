using System.Collections.Generic;
using System.Linq;

namespace Fridge
{
    public class FridgeService
    {
        private readonly IItemRepository _repository;

        public FridgeService(IItemRepository repository)
        {
            _repository = repository;
        }

        public bool IsAvailable(string itemName)
        {
            return _repository.GetAll().Any(x => x.Name == itemName);
        }

        public Quantity AddItem(Item item)
        {
            _repository.Add(item);
            List<Item> items = _repository.GetAll();

            return items.FirstOrDefault(x => x.Name == item.Name).Quantity;
        }

        public Quantity RemoveItem(Item item)
        {
            _repository.Remove(item);
            List<Item> items = _repository.GetAll();

            return items.FirstOrDefault(x => x.Name == item.Name).Quantity;
        }

        public List<Item> GetAllItems()
        {
            return _repository.GetAll();
        }
    }
}
