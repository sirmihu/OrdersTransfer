using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaselinkerApi;
using BaselinkerApi.Models;
using BaselinkerApi.Requests;
using FaireApi;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace TransferFaireOrdersToBaselinker
{
    public class TransferFaireOrdersToBaselinker
    {
        private readonly IFaireApi _faireApi;
        private readonly IBaselinkerApi _baselinkerApi;
        private readonly string _faireApiToken;
        private readonly string _baselinkerApiToken;

        public TransferFaireOrdersToBaselinker(IFaireApi faireApi, IBaselinkerApi baselinkerApi)
        {
            _faireApi = faireApi;
            _baselinkerApi = baselinkerApi;
            _faireApiToken = Environment.GetEnvironmentVariable("FaireApiToken", EnvironmentVariableTarget.Process);
            _baselinkerApiToken = Environment.GetEnvironmentVariable("BaselinkerApiToken", EnvironmentVariableTarget.Process);
        }

        [FunctionName("TransferFaireOrdersToBaselinker")]
        public async Task Run([TimerTrigger("* * * * *")]TimerInfo myTimer, ILogger log)
        {
            var faireOrders = await _faireApi.GetAllOrders(_faireApiToken);
            var faireOrdersInBaselinker = (await _baselinkerApi.GetOrders(
                new GetOrdersRequest
                {
                    FilterOrderSourceId = 1024
                }, _baselinkerApiToken)).Orders;


            foreach (var faireOrder in faireOrders)
            {
                if (faireOrdersInBaselinker.Any(p => p.ExtraField1 == faireOrder.Id))
                    continue;

                await _baselinkerApi.AddOrder(new AddOrderRequest
                {
                    OrderStatusId = 8069,
                    CustomSourceId = 1024,
                    ExtraField1 = faireOrder.Id,
                    DateAdd = (int)((DateTimeOffset)DateTime.Parse(faireOrder.CreatedAt)).ToUnixTimeSeconds(),
                    DeliveryFullname = faireOrder.Address.Name,
                    DeliveryCompany = faireOrder.Address.CompanyName,
                    DeliveryAddress = $"{faireOrder.Address.Address1},{faireOrder.Address.Address2}",
                    DeliveryPostcode = faireOrder.Address.PostalCode,
                    DeliveryCity = faireOrder.Address.City,
                    DeliveryState = faireOrder.Address.State,
                    DeliveryCountryCode = faireOrder.Address.CountryCode,
                    InvoiceFullname = faireOrder.Address.CompanyName,
                    InvoiceCompany = faireOrder.Address.CompanyName,
                    InvoiceAddress = $"{faireOrder.Address.Address1},{faireOrder.Address.Address2}",
                    InvoicePostcode = faireOrder.Address.PostalCode,
                    InvoiceCity = faireOrder.Address.City,
                    InvoiceState = faireOrder.Address.State,
                    InvoiceCountryCode = faireOrder.Address.CountryCode,
                    Phone = faireOrder.Address.PhoneNumber,
                    Products = faireOrder.Items.Select(item =>
                    new Product
                    {
                        Quantity = item.Quantity,
                        Sku = item.Sku,
                        PriceBrutto = item.PriceCents,
                        Name = item.ProductName,

                    }).ToList()
                }, _baselinkerApiToken);
            }

            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}

