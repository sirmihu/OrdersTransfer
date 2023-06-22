using System;
namespace FaireApi.Models
{
	public class PayoutCosts
	{
        public int PayoutFeeCents { get; set; }
        public int PayoutFeeBps { get; set; }
        public int CommissionCents { get; set; }
        public int CommissionBps { get; set; }
    }
}

