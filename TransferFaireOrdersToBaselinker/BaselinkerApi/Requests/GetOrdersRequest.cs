using Newtonsoft.Json;

namespace BaselinkerApi.Requests
{
    public class GetOrdersRequest
    {
        [JsonProperty("order_id")]
        public int OrderId { get; set; }
        [JsonProperty("date_confirmed_from")]
        public int DateConfirmedFrom { get; set; }
        [JsonProperty("date_from")]
        public int DateFrom { get; set; }
        [JsonProperty("id_from")]
        public int IdFrom { get; set; }
        [JsonProperty("get_unconfirmed_orders")]
        public bool GetUnconfirmedOrders { get; set; }
        [JsonProperty("include_custom_extra_fields")]
        public bool IncludeCustomExtraFields { get; set; }
        [JsonProperty("status_id")]
        public int StatusId { get; set; }
        [JsonProperty("filter_email")]
        public string? FilterEmail { get; set; }
        [JsonProperty("filter_order_source")]
        public string? FilterOrderSource { get; set; }
        [JsonProperty("filter_order_source_id")]
        public int FilterOrderSourceId { get; set; }
    }
}
