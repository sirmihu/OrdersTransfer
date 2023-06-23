using BaselinkerApi.Models;
using BaselinkerApi.Requests;
using BaselinkerApi.Responses;
using BaselinkerApi.Settings;
using RestSharp;
using RestSharp.Authenticators;
using System.Threading;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BaselinkerService
{
    public class BaselinkerApi : IBaselinkerApi
    {
        private readonly string _baseApiAddressUrl;
        private readonly string _token;
        private readonly RestClient _restClient;

        public BaselinkerApi(IOptions<BaselinkerApiSettings> options)
        {
            _baseApiAddressUrl = options.Value.BaseApiAddressUrl;
            _token = options.Value.Token;
            _restClient = new RestClient(new RestClientOptions(_baseApiAddressUrl));
        }

        public async Task<AddOrderResponse> AddOrder()
        {
            var restRequest = new RestRequest($"{BaselinkerApiUrlMethods.AddOrder}");
            restRequest.AddHeader("Authorization", $"Bearer {_token}");
            var response = await _restClient.PostAsync(restRequest);

            if (response.IsSuccessStatusCode)
            {
                var addOrderResponse = JsonConvert.DeserializeObject<AddOrderResponse>(response.Content);
                return addOrderResponse;
            }
            else
            {
                throw new Exception(response.ErrorMessage);
            }
        }



        public async Task<List<Order>> GetOrders()
        {
            var restRequest = new RestRequest($"{BaselinkerApiUrlMethods.GetOrders}");
            restRequest.AddHeader("Authorization", $"Bearer {_token}");
            var response = await _restClient.GetAsync<List<Order>>(restRequest);

            return response;
        }
    }
}

