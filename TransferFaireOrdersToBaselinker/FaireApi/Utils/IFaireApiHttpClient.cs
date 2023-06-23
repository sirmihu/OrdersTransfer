using RestSharp;

namespace FaireApi.Utils
{
    public interface IFaireApiHttpClient
    {
        Task<T> GetAsync<T>(string path, string token);
    }
}