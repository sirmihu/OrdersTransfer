using BaselinkerApi.Models;
using BaselinkerApi.Responses;

namespace BaselinkerService
{
    public interface IBaselinkerApi
    {
        Task<AddOrderResponse> AddOrder();
        Task<List<Order>> GetOrders();
    }
}