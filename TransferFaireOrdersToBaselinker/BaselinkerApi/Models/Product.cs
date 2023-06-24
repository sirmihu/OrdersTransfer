using Newtonsoft.Json;

namespace BaselinkerApi.Models
{
    public class Product
    {
        [JsonProperty("storage")]
        public string? Storage { get; set; }
        [JsonProperty("storage_id")]
        public int StorageId { get; set; }
        [JsonProperty("product_id")]
        public string? ProductId { get; set; }
        [JsonProperty("variant_id")]
        public int VariantId { get; set; }
        [JsonProperty("name")]
        public string? Name { get; set; }
        [JsonProperty("sku")]
        public string? Sku { get; set; }
        [JsonProperty("ean")]
        public string? Ean { get; set; }
        [JsonProperty("location")]
        public string? Location { get; set; }
        [JsonProperty("warehouse_id")]
        public int WarehouseId { get; set; }
        [JsonProperty("attributes")]
        public string? Attributes { get; set; }
        [JsonProperty("price_brutto")]
        public float PriceBrutto { get; set; }
        [JsonProperty("tax_rate")]
        public float TaxRate { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("weight")]
        public float Weight { get; set; }
    }

    public class GetOrdersProduct : Product
    {
        [JsonProperty("bundle_id")]
        public int BundleId { get; set; }

        [JsonProperty("order_product_id")]
        public int OrderProductId { get; set; }

        [JsonProperty("auction_id")]
        public int AuctionId { get; set; }
    }
}
