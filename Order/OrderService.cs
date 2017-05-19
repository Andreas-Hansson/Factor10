using System;
using System.Collections.Generic;
using System.Text;
using Kitchen;

namespace Order
{
    public class OrderService
    {
        private readonly IFridgeProxy _fridgeProxy;
        private readonly IReceiptRepository _receiptRepository;

        public OrderService(IFridgeProxy fridgeProxy, IReceiptRepository receiptRepository)
        {
            _fridgeProxy = fridgeProxy;
            _receiptRepository = receiptRepository;
        }

        public List<Availability> GetAvailableMeals()
        {
            var service = new ReceiptService(_fridgeProxy, _receiptRepository);
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
