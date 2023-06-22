using System;
using FaireApi.Models;

namespace FaireApi.Responses
{
	public class GetAllOrdersResponse
	{
		public int Page { get; set; }
		public int Limit { get; set; }
        public List<Order> Orders { get; set; }
    }
}

