using System;
using System.Net;

namespace FaireApi.Models
{
    public class Order
    {
        public string Id { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string State { get; set; }
        public List<Item> Items { get; set; }
        public Address Address { get; set; }
        public string RetailerId { get; set; }
        public PayoutCosts PayoutCosts { get; set; }
        public string Source { get; set; }
    }
}

