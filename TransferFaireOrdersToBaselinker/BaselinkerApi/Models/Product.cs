using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaselinkerApi.Models
{
    public class Product
    {
        [JsonPropertyName("storage")]
        public string Storage { get; set; }
        [JsonPropertyName("storage_id")]
        public int StorageId { get; set; }
        [JsonPropertyName("product_id")]
        public string ProductId { get; set; }
        [JsonPropertyName("variant_id")]
        public int VariantId { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("sku")]
        public string Sku { get; set; }
        [JsonPropertyName("ean")]
        public string Ean { get; set; }
        [JsonPropertyName("location")]
        public string Location { get; set; }
        [JsonPropertyName("warehouse_id")]
        public int WarehouseId { get; set; }
        [JsonPropertyName("attributes")]
        public string Attributes { get; set; }
        [JsonPropertyName("price_brutto")]
        public float PriceBrutto { get; set; }
        [JsonPropertyName("tax_rate")]
        public float TaxRate { get; set; }
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
        [JsonPropertyName("weight")]
        public float Weight { get; set; }
    }
}
