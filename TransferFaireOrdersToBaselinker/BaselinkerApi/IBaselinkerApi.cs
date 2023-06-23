using BaselinkerApi.Models;
using BaselinkerApi.Requests;
using BaselinkerApi.Responses;

namespace BaselinkerService
{
    public interface IBaselinkerApi
    {
        Task<AddOrderResponse> AddOrder(AddOrderRequest request);
        Task<GetOrdersResponse> GetOrders(GetOrdersRequest request);
    }
}