using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaselinkerApi.Models
{
    public class Order
    {
        [JsonPropertyName("order_id")]
        public int OrderId { get; set; }
        [JsonPropertyName("shop_order_id")]
        public int ShopOrderId { get; set; }
        [JsonPropertyName("external_order_id")]
        public string ExternalOrderId { get; set; }
        [JsonPropertyName("order_source")]
        public string OrderSource { get; set; }
        [JsonPropertyName("order_source_id")]
        public int OrderSourceId { get; set; }
        [JsonPropertyName("order_source_info")]
        public string OrderSourceInfo { get; set; }
        [JsonPropertyName("order_status_id")]
        public int OrderStatusId { get; set; }
        [JsonPropertyName("date_add")]
        public int DateAdd { get; set; }
        [JsonPropertyName("date_confirmed")]
        public int DateConfirmed { get; set; }
        [JsonPropertyName("date_in_status")]
        public int DateInStatus { get; set; }
        [JsonPropertyName("confirmed")]
        public bool Confirmed { get; set; }
        [JsonPropertyName("user_login")]
        public string UserLogin { get; set; }
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
        [JsonPropertyName("payment_method")]
        public string PaymentMethod { get; set; }
        [JsonPropertyName("payment_method_cod")]
        public bool PaymentMethodCod { get; set; }
        [JsonPropertyName("payment_done")]
        public float PaymentDone { get; set; }
        [JsonPropertyName("user_comments")]
        public string UserComments { get; set; }
        [JsonPropertyName("admin_comments")]
        public string AdminComments { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
        [JsonPropertyName("delivery_method")]
        public string DeliveryMethod { get; set; }
        [JsonPropertyName("delivery_price")]
        public float DeliveryPrice { get; set; }
        [JsonPropertyName("delivery_package_module")]
        public string DeliveryPackageModule { get; set; }
        [JsonPropertyName("delivery_package_nr")]
        public string DeliveryPackageNr { get; set; }
        [JsonPropertyName("delivery_fullname")]
        public string DeliveryFullname { get; set; }
        [JsonPropertyName("delivery_company")]
        public string DeliveryCompany { get; set; }
        [JsonPropertyName("delivery_address")]
        public string DeliveryAddress { get; set; }
        [JsonPropertyName("delivery_postcode")]
        public string DeliveryPostcode { get; set; }
        [JsonPropertyName("delivery_city")]
        public string DeliveryCity { get; set; }
        [JsonPropertyName("delivery_state")]
        public string DeliveryState { get; set; }
        [JsonPropertyName("delivery_country")]
        public string DeliveryCountry { get; set; }
        [JsonPropertyName("delivery_country_code")]
        public string DeliveryCountryCode { get; set; }
        [JsonPropertyName("delivery_point_id")]
        public string DeliveryPointId { get; set; }
        [JsonPropertyName("delivery_point_name")]
        public string DeliveryPointName { get; set; }
        [JsonPropertyName("delivery_point_address")]
        public string DeliveryPointAddress { get; set; }
        [JsonPropertyName("delivery_point_postcode")]
        public string DeliveryPointPostcode { get; set; }
        [JsonPropertyName("delivery_point_city")]
        public string DeliveryPointCity { get; set; }
        [JsonPropertyName("inovoice_fullname")]
        public string InvoiceFullname { get; set; }
        [JsonPropertyName("inovoice_company")]
        public string InvoiceCompany { get; set; }
        [JsonPropertyName("inovoice_nip")]
        public string InvoiceNip { get; set; }
        [JsonPropertyName("inovoice_address")]
        public string InvoiceAddress { get; set; }
        [JsonPropertyName("inovoice_postcode")]
        public string InvoicePostcode { get; set; }
        [JsonPropertyName("inovoice_city")]
        public string InvoiceCity { get; set; }
        [JsonPropertyName("inovoice_state")]
        public string InvoiceState { get; set; }
        [JsonPropertyName("inovoice_country")]
        public string InvoiceCountry { get; set; }
        [JsonPropertyName("inovoice_country_code")]
        public string InvoiceCountryCode { get; set; }
        [JsonPropertyName("want_inovoice")]
        public bool WantInvoice { get; set; }
        [JsonPropertyName("extra_field_1")]
        public string ExtraField1 { get; set; }
        [JsonPropertyName("extra_field_2")]
        public string ExtraField2 { get; set; }
        [JsonPropertyName("custom_extra_fields")]
        public Dictionary<object, object> CustomExtraFields { get; set; }
        [JsonPropertyName("order_page")]
        public string OrderPage { get; set; }
        [JsonPropertyName("pick_state")]
        public int PickState { get; set; }
        [JsonPropertyName("pack_state")]
        public int PackState { get; set; }
        [JsonPropertyName("products")]
        public List<Product> Products { get; set; }
    }
}
