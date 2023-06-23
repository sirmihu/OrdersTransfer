using System;
using System.Threading;
using FaireApi.Exceptions;
using FaireApi.Models;
using FaireApi.Responses;
using FaireApi.Settings;
using FaireApi.Utils;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FaireApi
{
    public class FaireApi : IFaireApi
    {
        private readonly string _token;
        private readonly int _maxOrdersLimitPerPage;
        private readonly IFaireApiHttpClient _faireApiHttpClient;

        public FaireApi(IFaireApiHttpClient faireApiHttpClient, IOptions<FaireApiSettings> options)
        {
            _faireApiHttpClient = faireApiHttpClient;
            _token = options.Value.Token;
            _maxOrdersLimitPerPage = 50;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            var page = 1;
            var orders = new List<Order>();

            while (true)
            {
                var path = $"{FaireApiUrl.GetAllOrders}?limit={_maxOrdersLimitPerPage}&page={page}";
                
                var getAllOrdersResponse = await _faireApiHttpClient.GetAsync<GetAllOrdersResponse>(path, _token)
                    ?? throw new FaireApiException($"Orders response was null, page: {page}");

                orders.AddRange(getAllOrdersResponse.Orders);

                var pageOrdersCount = getAllOrdersResponse.Orders.Count();
                if (pageOrdersCount < _maxOrdersLimitPerPage)
                    break;

                page++;
            }

            return orders;
        }
    }
}

