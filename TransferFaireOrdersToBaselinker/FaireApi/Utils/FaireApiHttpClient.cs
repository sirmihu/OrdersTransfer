﻿using FaireApi.Exceptions;
using FaireApi.Models;
using RestSharp;

namespace FaireApi.Utils
{
    public class FaireApiHttpClient : IFaireApiHttpClient
    {
        private readonly RestClient _restClient;

        public FaireApiHttpClient()
        {
            _restClient = new RestClient(new RestClientOptions(FaireApiUrl.BaseApiAddressUrl));
        }

        public async Task<T> GetAsync<T>(string path, string token)
        {
            try
            {
                var request = new RestRequest(path);
                request.AddHeader("X-FAIRE-ACCESS-TOKEN", token);

                return await _restClient.GetAsync<T>(request);
            }
            catch (Exception ex)
            {
                throw new FaireApiException(ex.Message);
            }
        }         
    }
}

