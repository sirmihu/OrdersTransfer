using BaselinkerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaselinkerApi.Requests
{
    public class AddOrderRequest
    {
        [JsonPropertyName("order_status_id")]
        public int OrderStatusId { get; set; }
        [JsonPropertyName("custom_source_id")]
        public int CustomSourceId { get; set; }
        [JsonPropertyName("date_add")]
        public int DateAdd { get; set; }
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
        [JsonPropertyName("payment_method")]
        public string PaymentMethod { get; set; }
        [JsonPropertyName("payment_method_cod")]
        public bool PaymentMethodCod { get; set; }
        [JsonPropertyName("paid")]
        public bool Paid { get; set; }
        [JsonPropertyName("user_comments")]
        public string UserComments { get; set; }
        [JsonPropertyName("admin_comments")]
        public string AdminComments { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
        [JsonPropertyName("user_login")]
        public string UserLogin { get; set; }
        [JsonPropertyName("delivery_method")]
        public string DeliveryMethod { get; set; }
        [JsonPropertyName("delivery_price")]
        public float DeliveryPrice { get; set; }
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
        [JsonPropertyName("invoice_fullname")]
        public string InvoiceFullname { get; set; }
        [JsonPropertyName("invoice_company")]
        public string InvoiceCompany { get; set; }
        [JsonPropertyName("invoice_nip")]
        public string InvoiceNip { get; set; }
        [JsonPropertyName("invoice_address")]
        public string InvoiceAddress { get; set; }
        [JsonPropertyName("invoice_postcode")]
        public string InvoicePostcode { get; set; }
        [JsonPropertyName("invoice_city")]
        public string InvoiceCity { get; set; }
        [JsonPropertyName("invoice_state")]
        public string InvoiceState { get; set; }
        [JsonPropertyName("invoice_country_code")]
        public string InvoiceCountryCode { get; set; }
        [JsonPropertyName("want_invoice")]
        public bool WantInvoice { get; set; }
        [JsonPropertyName("extra_field_1")]
        public string ExtraField1 { get; set; }
        [JsonPropertyName("extra_field_2")]
        public string ExtraField2 { get; set; }
        [JsonPropertyName("custom_extra_fields")]
        public Dictionary<object, object> CustomExtraFields { get; set; }
        [JsonPropertyName("products")]
        public List<Product> Products { get; set; }
    }
}
