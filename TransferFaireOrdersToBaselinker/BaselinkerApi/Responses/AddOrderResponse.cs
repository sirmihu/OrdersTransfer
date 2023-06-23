using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaselinkerApi.Responses
{
    public class AddOrderResponse
    { 
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("order_id")]
        public int OrderId { get; set; }
    }
}
