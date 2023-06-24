using System;
using System.Linq;
using System.Threading.Tasks;
using BaselinkerApi;
using BaselinkerApi.Models;
using BaselinkerApi.Requests;
using FaireApi;
using Microsoft.Azure.WebJobs;
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
        public async Task Run([TimerTrigger("*/10 * * * *")]TimerInfo myTimer, ILogger log)
        {
            try
            {
                log.LogInformation("Transfer Faire orders to Baselinker process started.");

                var faireOrders = await _faireApi.GetAllOrders(_faireApiToken);
                var faireOrdersInBaselinker = (await _baselinkerApi.GetOrders(
                    new GetOrdersRequest
                    {
                        FilterOrderSourceId = SourceOrder.FaireSystemId
                    }, _baselinkerApiToken)).Orders;


                foreach (var faireOrder in faireOrders)
                {
                    if (faireOrdersInBaselinker.Any(p => p.ExtraField1 == faireOrder.Id))
                    {
                        log.LogInformation($"Faire order, id: {faireOrder.Id} already exists in Baselinker," +
                            " it will be ommitted in transfer process.");
                        continue;
                    }                       

                    var addOrderResult = await _baselinkerApi.AddOrder(new AddOrderRequest
                    {
                        OrderStatusId = OrderStatus.FaireOrderStatus,
                        CustomSourceId = SourceOrder.FaireSystemId,
                        ExtraField1 = faireOrder.Id,
                        DateAdd = (int)((DateTimeOffset)DateTime.ParseExact(faireOrder.CreatedAt, "yyyyMMddTHHmmss.fffZ",
                            System.Globalization.CultureInfo.InvariantCulture)).ToUnixTimeSeconds(),
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

                    if (addOrderResult.Status != AddOrderStatus.Success)
                    {
                        log.LogError($"There was an error while adding order to Baselinker, Faire order id: {faireOrder.Id}");
                        continue;
                    }

                    log.LogInformation($"Faire order, id: {faireOrder.Id} successfully transfered to Baselinker.");
                }

                log.LogInformation($"Transfer Faire orders to Baselinker successfully processed.");
            }
            catch (Exception ex)
            {
                log.LogError("TransferFaireOrdersToBaselinker error:" +
                    $" Exception type: {ex.GetType().Name}, Exception message: {ex.Message}, Time: {DateTime.Now}");
            }           
        }
    }
}

