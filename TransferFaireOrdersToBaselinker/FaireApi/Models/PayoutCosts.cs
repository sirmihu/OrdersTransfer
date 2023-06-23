using System;
using Newtonsoft.Json;

namespace FaireApi.Models
{
	public class PayoutCosts
	{
        [JsonProperty("payout_fee_cents")]
        public int PayoutFeeCents { get; set; }
        [JsonProperty("payout_fee_bps")]
        public int PayoutFeeBps { get; set; }
        [JsonProperty("commission_cents")]
        public int CommissionCents { get; set; }
        [JsonProperty("commission_bps")]
        public int CommissionBps { get; set; }
    }
}

