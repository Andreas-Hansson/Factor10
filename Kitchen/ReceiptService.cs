using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;


namespace Kitchen
{
    public class ReceiptService
    {
        private readonly IFridgeProxy _fridgeProxy;
        private readonly IReceiptRepository _receiptRepository;

        public ReceiptService(IFridgeProxy fridgeItemRepository, IReceiptRepository receiptRepository)
        {

            _fridgeProxy = fridgeItemRepository;
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
            var items = _fridgeProxy.GetAll();

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
