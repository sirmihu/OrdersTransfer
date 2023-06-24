using BaselinkerApi.Exceptions;
using BaselinkerApi.Models;
using BaselinkerApi.Requests;
using BaselinkerApi.Responses;
using BaselinkerApi.Settings;
using BaselinkerApi.Utils;
using Moq;
using Xunit;

namespace BaselinkerApi.Tests;

public class BaselinkerApiTests
{
    private readonly BaselinkerApi _baseLinkerApi;
    private readonly Mock<IBaselinkerApiHttpClient> _mockBaselinkerApiHttpClient;
    private readonly string _token;

    public BaselinkerApiTests()
    {
        _token = "testToken";
        _mockBaselinkerApiHttpClient = new Mock<IBaselinkerApiHttpClient>();

        _baseLinkerApi = new BaselinkerApi(_mockBaselinkerApiHttpClient.Object);
    }

    [Fact]
    public async void AddOrder_Should_Return_CorrectResponse()
    {
        // Arrange
        var request = new AddOrderRequest
        {
            OrderStatusId = 8069,
            CustomSourceId = 1024,
            ExtraField1 = "faireTestId",
            DateAdd = 1234,
            DeliveryFullname = "John Doe",
            DeliveryCompany = "Test Company",
            DeliveryAddress = "Test Address",
            DeliveryPostcode = "Test PostCode",
            DeliveryCity = "Test City",
            DeliveryState = "Test State",
            DeliveryCountryCode = "Test CountryCode",
            InvoiceFullname = "John Doe",
            InvoiceCompany = "Test Company",
            InvoiceAddress = "Test Address",
            InvoicePostcode = "Test PostCode",
            InvoiceCity = "Test City",
            InvoiceState = "Test State",
            InvoiceCountryCode = "Test CountryCode",
            UserComments = "test",
            AdminComments = "test",
            Phone = "1234567890",
            Products = new List<Product>
            {
                new Product
                {
                    WarehouseId = 1,
                    Quantity = 1,
                    Sku = "test",
                    PriceBrutto = 1000,
                    Name = "TestName"
                }
            }
        };
        var expectedResponse = new AddOrderResponse
        {
            OrderId = 1,
            Status = "SUCCESS"
        };

        _mockBaselinkerApiHttpClient.Setup(p => p.PostAsync<AddOrderRequest, AddOrderResponse>(
            request, BaselinkerApiUrl.AddOrder, _token))
            .ReturnsAsync(expectedResponse);

        // Act
        var result = await _baseLinkerApi.AddOrder(request, _token);

        // Assert
        Assert.Equal(result, expectedResponse);
    }

    [Fact]
    public async void AddOrder_Throws_BaselinkerApiException_When_ErrorOnBaselinkerApiSide()
    {
        // Arrange
        var request = new AddOrderRequest
        {
            OrderStatusId = 8069,
            CustomSourceId = 1024,
            ExtraField1 = "faireTestId",
        };

        // Act & Assert
        await Assert.ThrowsAsync<BaselinkerApiException>(async () => await _baseLinkerApi.AddOrder(request, _token));
    }

    [Fact]
    public async void GetOrders_Should_Return_CorrectResponse()
    {
        // Arrange
        var request = new GetOrdersRequest
        {
            FilterOrderSourceId = 1024
        };

        var expectedResponse = new GetOrdersResponse
        {
            Status = "SUCCESS",
            Orders = new List<Order>()
            {
                new Order()
                {
                    OrderStatusId = 8069,
                    OrderSourceId = 1024,
                    ExtraField1 = "faireTestId",
                    DateAdd = 1234,
                    DeliveryFullname = "John Doe",
                    DeliveryCompany = "Test Company",
                    DeliveryAddress = "Test Address",
                    DeliveryPostcode = "Test PostCode",
                    DeliveryCity = "Test City",
                    DeliveryState = "Test State",
                    DeliveryCountryCode = "Test CountryCode",
                    InvoiceFullname = "John Doe",
                    InvoiceCompany = "Test Company",
                    InvoiceAddress = "Test Address",
                    InvoicePostcode = "Test PostCode",
                    InvoiceCity = "Test City",
                    InvoiceState = "Test State",
                    InvoiceCountryCode = "Test CountryCode",
                    UserComments = "test",
                    AdminComments = "test",
                    Phone = "1234567890",
                    Products = new List<GetOrdersProduct>
                    {
                        new GetOrdersProduct
                        {
                            WarehouseId = 1,
                            Quantity = 1,
                            Sku = "test",
                            PriceBrutto = 1000,
                            Name = "TestName",
                            AuctionId = 1,
                            BundleId = 1,
                            OrderProductId = 1
                        }
                    }
                }
            }
        };

        _mockBaselinkerApiHttpClient.Setup(p => p.PostAsync<GetOrdersRequest, GetOrdersResponse>(
            request, BaselinkerApiUrl.GetOrders, _token))
            .ReturnsAsync(expectedResponse);

        // Act
        var result = await _baseLinkerApi.GetOrders(request, _token);

        // Assert
        Assert.Equal(result, expectedResponse);
    }

    [Fact]
    public async void GetOrders_Throws_BaselinkerApiException_When_ErrorOnBaselinkerApiSide()
    {
        // Arrange
        var request = new GetOrdersRequest
        {
            FilterOrderSourceId = 1024
        };

        // Act & Assert
        await Assert.ThrowsAsync<BaselinkerApiException>(async () => await _baseLinkerApi.GetOrders(request, _token));
    }
}
