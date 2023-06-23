using BaselinkerApi.Requests;
using BaselinkerApi.Responses;
using BaselinkerApi.Settings;
using BaselinkerApi.Utils;
using BaselinkerApi.Exceptions;

namespace BaselinkerApi
{
    public class BaselinkerApi : IBaselinkerApi
    {
        private readonly IBaselinkerApiHttpClient _baselinkerHttpClient;

        public BaselinkerApi(IBaselinkerApiHttpClient baselinkerHttpClient)
        {
            _baselinkerHttpClient = baselinkerHttpClient;
        }

        public async Task<AddOrderResponse> AddOrder(AddOrderRequest request, string token)
        {
            try
            {
                var response = await _baselinkerHttpClient.PostAsync<AddOrderRequest, AddOrderResponse>(request, BaselinkerApiUrl.AddOrder, token)
                    ?? throw new BaselinkerApiException("AddOrder response was null.");

                return response;
            }
            catch (Exception ex)
            {
                throw new BaselinkerApiException(ex.Message);
            }
        }

        public async Task<GetOrdersResponse> GetOrders(GetOrdersRequest request, string token)
        {
            try
            {
                var response =  await _baselinkerHttpClient.PostAsync<GetOrdersRequest, GetOrdersResponse>(request, BaselinkerApiUrl.GetOrders, token)
                    ?? throw new BaselinkerApiException("GetOrders response was null.");

                return response;
            }
            catch (Exception ex)
            {
                throw new BaselinkerApiException(ex.Message);
            }
        }
    }
}

