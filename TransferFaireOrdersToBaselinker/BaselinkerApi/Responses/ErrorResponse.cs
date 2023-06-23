using System;
using System.Text.Json.Serialization;

namespace BaselinkerApi.Responses
{
	public class ErrorResponse
	{
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("error_code")]
        public string ErrorCode { get; set; }
        [JsonPropertyName("error_message")]
        public string ErrorMessage { get; set; }
	}
}

