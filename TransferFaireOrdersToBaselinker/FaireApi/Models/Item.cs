using System;
namespace FaireApi.Models
{
	public class Item
	{
        public string Id { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public string ProductOptionId { get; set; }
        public int Quantity { get; set; }
        public string Sku { get; set; }
        public int PriceCents { get; set; }
        public string ProductName { get; set; }
        public string ProductOptionName { get; set; }
        public bool IncludesTester { get; set; }
    }
}

