using FaireApi.Models;
using Newtonsoft.Json;

namespace FaireApi.Responses
{
	public class GetAllOrdersResponse
	{
        [JsonProperty("page")]
        public int Page { get; set; }
        [JsonProperty("limit")]
        public int Limit { get; set; }
        [JsonProperty("orders")]
        public List<Order> Orders { get; set; }
    }
}

