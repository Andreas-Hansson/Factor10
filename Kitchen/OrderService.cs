using System;
using System.Collections.Generic;
using System.Text;
using Kitchen;

namespace Order
{
    public class OrderService
    {
        private readonly Fridge.IItemRepository _fridgeItemRepository;
        private readonly IReceiptRepository _receiptRepository;

        public OrderService(Fridge.IItemRepository fridgeItemRepository, IReceiptRepository receiptRepository)
        {
            _fridgeItemRepository = fridgeItemRepository;
            _receiptRepository = receiptRepository;
        }

        public List<Availability> GetAvailableMeals()
        {
            var service = new ReceiptService(_fridgeItemRepository, _receiptRepository);
            var possibleMeals = service.GetPossibleMeals();
            var availabilities = new List<Availability>();
            foreach (var meal in possibleMeals)
            {
                var availablilty = new Availability();
                availablilty.Meal = meal.Meal;
                availabilities.Add(availablilty);
            }

            return availabilities;
        }
    }
}
