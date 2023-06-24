using BaselinkerApi.Responses;
using Newtonsoft.Json;

namespace BaselinkerApi.Models
{
    public class Order
    {
        [JsonProperty("order_id")]
        public int OrderId { get; set; }
        [JsonProperty("shop_order_id")]
        public int ShopOrderId { get; set; }
        [JsonProperty("external_order_id")]
        public string ExternalOrderId { get; set; }
        [JsonProperty("order_source")]
        public string OrderSource { get; set; }
        [JsonProperty("order_source_id")]
        public int OrderSourceId { get; set; }
        [JsonProperty("order_source_info")]
        public string OrderSourceInfo { get; set; }
        [JsonProperty("order_status_id")]
        public int OrderStatusId { get; set; }
        [JsonProperty("date_add")]
        public int DateAdd { get; set; }
        [JsonProperty("date_confirmed")]
        public int DateConfirmed { get; set; }
        [JsonProperty("date_in_status")]
        public int DateInStatus { get; set; }
        [JsonProperty("confirmed")]
        public bool Confirmed { get; set; }
        [JsonProperty("user_login")]
        public string UserLogin { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("payment_method")]
        public string PaymentMethod { get; set; }
        [JsonProperty("payment_method_cod")]
        public bool PaymentMethodCod { get; set; }
        [JsonProperty("payment_done")]
        public float PaymentDone { get; set; }
        [JsonProperty("user_comments")]
        public string UserComments { get; set; }
        [JsonProperty("admin_comments")]
        public string AdminComments { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("delivery_method")]
        public string DeliveryMethod { get; set; }
        [JsonProperty("delivery_price")]
        public float DeliveryPrice { get; set; }
        [JsonProperty("delivery_package_module")]
        public string DeliveryPackageModule { get; set; }
        [JsonProperty("delivery_package_nr")]
        public string DeliveryPackageNr { get; set; }
        [JsonProperty("delivery_fullname")]
        public string DeliveryFullname { get; set; }
        [JsonProperty("delivery_company")]
        public string DeliveryCompany { get; set; }
        [JsonProperty("delivery_address")]
        public string DeliveryAddress { get; set; }
        [JsonProperty("delivery_postcode")]
        public string DeliveryPostcode { get; set; }
        [JsonProperty("delivery_city")]
        public string DeliveryCity { get; set; }
        [JsonProperty("delivery_state")]
        public string DeliveryState { get; set; }
        [JsonProperty("delivery_country")]
        public string DeliveryCountry { get; set; }
        [JsonProperty("delivery_country_code")]
        public string DeliveryCountryCode { get; set; }
        [JsonProperty("delivery_point_id")]
        public string DeliveryPointId { get; set; }
        [JsonProperty("delivery_point_name")]
        public string DeliveryPointName { get; set; }
        [JsonProperty("delivery_point_address")]
        public string DeliveryPointAddress { get; set; }
        [JsonProperty("delivery_point_postcode")]
        public string DeliveryPointPostcode { get; set; }
        [JsonProperty("delivery_point_city")]
        public string DeliveryPointCity { get; set; }
        [JsonProperty("inovoice_fullname")]
        public string InvoiceFullname { get; set; }
        [JsonProperty("inovoice_company")]
        public string InvoiceCompany { get; set; }
        [JsonProperty("inovoice_nip")]
        public string InvoiceNip { get; set; }
        [JsonProperty("inovoice_address")]
        public string InvoiceAddress { get; set; }
        [JsonProperty("inovoice_postcode")]
        public string InvoicePostcode { get; set; }
        [JsonProperty("inovoice_city")]
        public string InvoiceCity { get; set; }
        [JsonProperty("inovoice_state")]
        public string InvoiceState { get; set; }
        [JsonProperty("inovoice_country")]
        public string InvoiceCountry { get; set; }
        [JsonProperty("inovoice_country_code")]
        public string InvoiceCountryCode { get; set; }
        [JsonProperty("want_inovoice")]
        public bool WantInvoice { get; set; }
        [JsonProperty("extra_field_1")]
        public string ExtraField1 { get; set; }
        [JsonProperty("extra_field_2")]
        public string ExtraField2 { get; set; }
        [JsonProperty("custom_extra_fields")]
        public Dictionary<object, object> CustomExtraFields { get; set; }
        [JsonProperty("order_page")]
        public string OrderPage { get; set; }
        [JsonProperty("pick_state")]
        public int PickState { get; set; }
        [JsonProperty("pack_state")]
        public int PackState { get; set; }
        [JsonProperty("products")]
        public List<GetOrdersProduct> Products { get; set; }
    }
}
