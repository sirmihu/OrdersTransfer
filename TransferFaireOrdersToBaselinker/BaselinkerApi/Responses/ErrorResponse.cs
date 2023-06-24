using Newtonsoft.Json;

namespace BaselinkerApi.Responses
{
	public class ErrorResponse
	{
        [JsonProperty("status")]
        public string? Status { get; set; }
        [JsonProperty("error_code")]
        public string? ErrorCode { get; set; }
        [JsonProperty("error_message")]
        public string? ErrorMessage { get; set; }
	}
}

