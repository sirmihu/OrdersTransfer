using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaselinkerApi.Requests
{
    public class GetOrdersRequest
    {
        [JsonPropertyName("order_id")]
        public int OrderId { get; set; }
        [JsonPropertyName("date_confirmed_from")]
        public int DateConfirmedFrom { get; set; }
        [JsonPropertyName("date_from")]
        public int DateFrom { get; set; }
        [JsonPropertyName("id_from")]
        public int IdFrom { get; set; }
        [JsonPropertyName("get_unconfirmed_orders")]
        public bool GetUnconfirmedOrders { get; set; }
        [JsonPropertyName("include_custom_extra_fields")]
        public bool IncludeCustomExtraFields { get; set; }
        [JsonPropertyName("status_id")]
        public int StatusId { get; set; }
        [JsonPropertyName("filter_email")]
        public string FilterEmail { get; set; }
        [JsonPropertyName("filter_order_source")]
        public string FilterOrderSource { get; set; }
        [JsonPropertyName("filter_order_source_id")]
        public int FilterOrderSourceId { get; set; }
    }
}
