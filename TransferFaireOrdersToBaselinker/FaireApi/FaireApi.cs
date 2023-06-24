using FaireApi.Exceptions;
using FaireApi.Models;
using FaireApi.Responses;
using FaireApi.Utils;

namespace FaireApi
{
    public class FaireApi : IFaireApi
    {
        private readonly int _maxOrdersLimitPerPage;
        private readonly IFaireApiHttpClient _faireApiHttpClient;

        public FaireApi(IFaireApiHttpClient faireApiHttpClient)
        {
            _faireApiHttpClient = faireApiHttpClient;
            _maxOrdersLimitPerPage = 50;
        }

        public async Task<IEnumerable<Order>> GetAllOrders(string token)
        {
            var page = 1;
            var orders = new List<Order>();

            while (true)
            {
                var path = $"{FaireApiUrl.GetAllOrders}?limit={_maxOrdersLimitPerPage}&page={page}";
                
                var getAllOrdersResponse = await _faireApiHttpClient.GetAsync<GetAllOrdersResponse>(path, token)
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

