using System;
using System.Threading;
using FaireApi.Exceptions;
using FaireApi.Models;
using FaireApi.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace FaireApi
{
    public class FaireApi : IFaireApi
    {
        private readonly string _baseApiAddressUrl;
        private readonly string _token;
        private readonly int _maxOrdersLimitPerPage;
        private readonly IRestClient _restClient;

        public FaireApi(IRestClient restClient, IOptions<FaireApiSettings> options)
        {
            _restClient = restClient;
            _baseApiAddressUrl = options.Value.BaseApiAddressUrl;
            _token = options.Value.Token;
            _maxOrdersLimitPerPage = 50;
            _restClient = new RestClient(new RestClientOptions(_baseApiAddressUrl));
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            var page = 1;
            var pageOrdersCount = 0;
            var orders = new List<Order>();

            while (pageOrdersCount < _maxOrdersLimitPerPage)
            {
                var restRequest = new RestRequest($"{FaireApiUrl.GetAllOrders}?limit={_maxOrdersLimitPerPage}&page={page}");
                restRequest.AddHeader("Authorization", $"Bearer {_token}");

                var pageOrders = await _restClient.GetAsync<IEnumerable<Order>>(restRequest)
                    ?? throw new FaireApiException($"Orders response was null, page: {page}");

                orders.AddRange(pageOrders);

                pageOrdersCount = pageOrders.Count();
                page++;
            }

            return orders;
        }
    }
}

