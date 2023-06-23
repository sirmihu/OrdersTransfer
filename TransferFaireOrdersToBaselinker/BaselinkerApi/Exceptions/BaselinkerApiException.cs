using System;
namespace BaselinkerApi.Exceptions
{
	public class BaselinkerApiException : Exception
	{
        public BaselinkerApiException(string? message)
            : base($"Baselinker Api exception: {message}") { }
    }
}

