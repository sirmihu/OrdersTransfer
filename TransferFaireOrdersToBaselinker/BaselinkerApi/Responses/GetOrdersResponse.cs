using BaselinkerApi.Models;
using Newtonsoft.Json;

namespace BaselinkerApi.Responses
{
    public class GetOrdersResponse
    {
        [JsonProperty("status")]
        public string? Status { get; set; }
        [JsonProperty("orders")]
        public List<Order>? Orders { get; set; }
    }
}
