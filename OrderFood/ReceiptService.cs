using System.Collections.Generic;
using System.Linq;

namespace Kitchen
{
    public class ReceiptService
    {
        private readonly Fridge.IItemRepository _fridgeItemRepository;

        public ReceiptService(Fridge.IItemRepository fridgeItemRepository)
        {

            _fridgeItemRepository = fridgeItemRepository;
        }

        public Receipt GetReceipt(string pancakeReceipt)
        {
            var receipRep = new ReceiptRepository();
            return receipRep.GetAllReceipts().FirstOrDefault(x => x.Name == pancakeReceipt);
        }

        public List<Availability> GetPossibleMeals()
        {
            var receipRep = new ReceiptRepository();
            return (from receipt in receipRep.GetAllReceipts() where PossibleToCook(receipt) select new Availability() {Meal = receipt.Name}).ToList();
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

    }

}
