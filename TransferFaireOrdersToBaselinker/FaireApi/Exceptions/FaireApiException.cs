using System;
namespace FaireApi.Exceptions
{
    public class FaireApiException : Exception
    {
        public FaireApiException(string? message)
            : base($"Faire Api exception: {message}") { }
    }
}

