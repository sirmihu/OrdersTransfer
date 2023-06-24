using BaselinkerApi.Exceptions;
using BaselinkerApi.Responses;
using BaselinkerApi.Settings;
using Newtonsoft.Json;
using RestSharp;

namespace BaselinkerApi.Utils
{
    public class BaselinkerApiHttpClient : IBaselinkerApiHttpClient
    {
        private readonly RestClient _restClient;

        public BaselinkerApiHttpClient()
        {
            _restClient = new RestClient(new RestClientOptions(BaselinkerApiUrl.BaseApiAddressUrl));
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request, string method, string token)
        {
            var content = $"method={method}&parameters={JsonConvert.SerializeObject(request)}";

            var restRequest = new RestRequest();
            restRequest.AddHeader("X-BLToken", token);
            restRequest.AddBody(content);

            var response = await _restClient.PostAsync(restRequest);
            if (!response.IsSuccessStatusCode)
            {
                var error = JsonConvert.DeserializeObject<ErrorResponse>(response.Content);
                throw new BaselinkerApiException($"Error code: {error.ErrorCode}, Error message: {error.ErrorMessage}.");
            }

            return JsonConvert.DeserializeObject<TResponse>(response.Content);
        }
    }
}

