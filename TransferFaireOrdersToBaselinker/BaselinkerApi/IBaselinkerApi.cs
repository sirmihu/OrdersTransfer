using BaselinkerApi.Requests;
using BaselinkerApi.Responses;

namespace BaselinkerApi
{
    public interface IBaselinkerApi
    {
        Task<AddOrderResponse> AddOrder(AddOrderRequest request, string token);
        Task<GetOrdersResponse> GetOrders(GetOrdersRequest request, string token);
    }
}