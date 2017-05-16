using System.Collections.Generic;
using System.Linq;


namespace Kitchen
{
    public class ReceiptService
    {
        private readonly Fridge.IItemRepository _fridgeItemRepository;
        private readonly IReceiptRepository _receiptRepository;

        public ReceiptService(Fridge.IItemRepository fridgeItemRepository, IReceiptRepository receiptRepository)
        {

            _fridgeItemRepository = fridgeItemRepository;
            _receiptRepository = receiptRepository;
        }

        public Receipt GetReceipt(string pancakeReceipt)
        {
            return _receiptRepository.GetAllReceipts().FirstOrDefault(x => x.Name == pancakeReceipt);
        }

        public List<Availability> GetPossibleMeals()
        {
            return (from receipt in _receiptRepository.GetAllReceipts() where PossibleToCook(receipt) select new Availability() {Meal = receipt.Name}).ToList();
        }

        public bool PossibleToCook(Receipt receipt)
        {
            var items = _fridgeItemRepository.GetAll();

            foreach (var receiptItem in receipt.Ingredients)
            {
                if (!items.Any(x => x.Name == receiptItem.Name && x.Quantity.Total >= receiptItem.Quantity.Total))
                    return false;
            }
            return true;
        }

        public void AddRecipt(Receipt receipt)
        {
            _receiptRepository.Add(receipt);
        }
    }

}
