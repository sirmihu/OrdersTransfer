using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaselinkerApi.Models;

namespace BaselinkerApi.Responses
{
    public class GetOrdersResponse
    {
        public string Status { get; set; }
        public List<Order> Orders { get; set; }
    }
}
