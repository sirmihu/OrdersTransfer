using FaireApi.Models;

namespace FaireApi
{
    public interface IFaireApi
    {
        Task<IEnumerable<Order>> GetAllOrders();
    }
}