using System;
using System.Collections.Generic;
using System.Text;

namespace Order
{
    public class OrderService
    {
        private readonly Kitchen.IReceiptRepository _receiptRepository;

        public OrderService(Kitchen.IReceiptRepository receiptRepository)
        {

            _receiptRepository = receiptRepository;
        }

        public List<Availability> GetAvailableMeals()
        {
            return null;
        }
    }
}
