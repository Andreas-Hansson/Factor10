using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Kitchen;
using Newtonsoft.Json;
using RestSharp;


namespace Kitchen
{
    public class FridgeProxy: IFridgeProxy
    {
        public List<FridgeItem> GetAll()
        {
            var client = new RestClient("http://localhost:51698/api");
            var request = new RestRequest("item", Method.GET);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            return JsonConvert.DeserializeObject<List<FridgeItem>>(response.Content);
        }

        public void Add(FridgeItem item)
        {
            throw new NotImplementedException();
        }

        public void Remove(FridgeItem item)
        {
            throw new NotImplementedException();
        }


        private static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }

    public interface IFridgeProxy
    {
        List<FridgeItem> GetAll();

        void Add(FridgeItem item);

        void Remove(FridgeItem item);
    }
}
