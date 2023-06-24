using Newtonsoft.Json;

namespace BaselinkerApi.Responses
{
    public class AddOrderResponse
    { 
        [JsonProperty("status")]
        public string? Status { get; set; }
        [JsonProperty("order_id")]
        public int OrderId { get; set; }
    }
}
