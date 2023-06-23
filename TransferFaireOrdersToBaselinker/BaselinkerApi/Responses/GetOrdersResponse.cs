using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BaselinkerApi.Models;

namespace BaselinkerApi.Responses
{
    public class GetOrdersResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("orders")]
        public List<Order> Orders { get; set; }
    }
}
