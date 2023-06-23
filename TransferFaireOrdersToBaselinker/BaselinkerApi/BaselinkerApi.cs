﻿using BaselinkerApi.Models;
using BaselinkerApi.Requests;
using BaselinkerApi.Responses;
using BaselinkerApi.Settings;
using RestSharp;
using RestSharp.Authenticators;
using System.Threading;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using BaselinkerApi.Utils;
using BaselinkerApi.Exceptions;

namespace BaselinkerApi
{
    public class BaselinkerApi : IBaselinkerApi
    {
        private readonly string _token;
        private readonly IBaselinkerApiHttpClient _baselinkerHttpClient;

        public BaselinkerApi(IBaselinkerApiHttpClient baselinkerHttpClient, IOptions<BaselinkerApiSettings> options)
        {
            _baselinkerHttpClient = baselinkerHttpClient;
            _token = options.Value.Token;
        }

        public async Task<AddOrderResponse> AddOrder(AddOrderRequest request)
        {
            try
            {
                var response = await _baselinkerHttpClient.PostAsync<AddOrderRequest, AddOrderResponse>(request, BaselinkerApiUrl.AddOrder, _token)
                    ?? throw new BaselinkerApiException("AddOrder response was null.");

                return response;
            }
            catch (Exception ex)
            {
                throw new BaselinkerApiException(ex.Message);
            }
        }

        public async Task<GetOrdersResponse> GetOrders(GetOrdersRequest request)
        {
            try
            {
                var response =  await _baselinkerHttpClient.PostAsync<GetOrdersRequest, GetOrdersResponse>(request, BaselinkerApiUrl.GetOrders, _token)
                    ?? throw new BaselinkerApiException("GetOrders response was null.");

                return response;
            }
            catch (Exception ex)
            {
                throw new BaselinkerApiException(ex.Message);
            }
        }
    }
}

