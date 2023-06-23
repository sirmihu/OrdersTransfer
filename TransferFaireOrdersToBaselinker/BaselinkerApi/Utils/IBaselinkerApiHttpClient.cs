namespace BaselinkerApi.Utils
{
    public interface IBaselinkerApiHttpClient
    {
        Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request, string method, string token);
    }
}