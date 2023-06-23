namespace BaselinkerApi.Utils
{
    public interface IBaselinkerHttpClient
    {
        Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request, string method, string token);
    }
}