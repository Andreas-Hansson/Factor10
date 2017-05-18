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

        public bool PossibleToCookAPI(Receipt receipt)
        {
            var client = new RestClient("http://localhost:51698/api");
            var request = new RestRequest("item", Method.GET);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            var items = JsonConvert.DeserializeObject<List<Item>>(response.Content);


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


        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }

}
