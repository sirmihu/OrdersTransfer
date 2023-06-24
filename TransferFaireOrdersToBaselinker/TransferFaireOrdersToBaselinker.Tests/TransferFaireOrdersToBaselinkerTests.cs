using BaselinkerApi;
using BaselinkerModels = BaselinkerApi.Models;
using FaireModels = FaireApi.Models;
using FaireApi;
using Moq;
using Xunit;
using BaselinkerApi.Requests;
using BaselinkerApi.Responses;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace TransferFaireOrdersToBaselinker.Tests
{
    public class TransferFaireOrdersToBaselinkerTests
    {
        private readonly Mock<IFaireApi> _faireApiMock;
        private readonly Mock<IBaselinkerApi> _baselinkerApiMock;
        private readonly Mock<ILogger<TransferFaireOrdersToBaselinker>> _mockLogger;
        private readonly TransferFaireOrdersToBaselinker _transferFaireOrdersToBaselinker;

        public TransferFaireOrdersToBaselinkerTests()
        {
            _faireApiMock = new Mock<IFaireApi>();
            _baselinkerApiMock = new Mock<IBaselinkerApi>();
            _mockLogger = new Mock<ILogger<TransferFaireOrdersToBaselinker>>();

            _transferFaireOrdersToBaselinker = new TransferFaireOrdersToBaselinker(_faireApiMock.Object, _baselinkerApiMock.Object);
        }

        [Fact]
        public async Task TransferFaireOrdersToBaselinker_Should_SuccessfullyTransferOrders()
        {
            // Arrange
            _faireApiMock.Setup(p => p.GetAllOrders(It.IsAny<string>()))
                .ReturnsAsync(new List<FaireModels.Order>
                {
                    new FaireModels.Order
                    {
                        Id = "testId1",
                        CreatedAt = "20190315T000915.000Z",
                        Address = GetTestFaireAddress(),
                        Items = GetTestFaireItems()
                    },
                    new FaireModels.Order
                    {
                        Id = "testId2",
                        CreatedAt = "20190415T000915.000Z",
                        Address = GetTestFaireAddress(),
                        Items = GetTestFaireItems()
                    }
                });

            _baselinkerApiMock.Setup(p => p.GetOrders(It.IsAny<GetOrdersRequest>(), It.IsAny<string>()))
                .ReturnsAsync(new GetOrdersResponse
                {
                    Status = "SUCCESS",
                    Orders = new List<BaselinkerModels.Order>
                    {
                        new BaselinkerModels.Order
                        {
                            ExtraField1 = "testId3"
                        },
                        new BaselinkerModels.Order
                        {
                            ExtraField1 = "testId4"
                        }
                    }
                });

            _baselinkerApiMock.Setup(p => p.AddOrder(It.IsAny<AddOrderRequest>(), It.IsAny<string>()))
                .ReturnsAsync(GetSuccessBaselinkerAddOrderResponse());

            // Act
            await _transferFaireOrdersToBaselinker.Run(default(TimerInfo), _mockLogger.Object);

            // Assert
            _faireApiMock.Verify(p => p.GetAllOrders(It.IsAny<string>()), Times.Once());
            _baselinkerApiMock.Verify(p => p.GetOrders(It.IsAny<GetOrdersRequest>(), It.IsAny<string>()), Times.Once());
            _baselinkerApiMock.Verify(p => p.AddOrder(It.IsAny<AddOrderRequest>(), It.IsAny<string>()), Times.Exactly(2));
        }

        [Fact]
        public async Task TransferFaireOrdersToBaselinker_Should_SuccessfullyTransferOrders_When_FaireOrderAlreadyExistsInBaselinker()
        {
            // Arrange
            _faireApiMock.Setup(p => p.GetAllOrders(It.IsAny<string>()))
                .ReturnsAsync(new List<FaireModels.Order>
                {
                    new FaireModels.Order
                    {
                        Id = "testId1",
                        CreatedAt = "20190315T000915.000Z",
                        Address = GetTestFaireAddress(),
                        Items = GetTestFaireItems()
                    },
                    new FaireModels.Order
                    {
                        Id = "testId2",
                        CreatedAt = "20190415T000915.000Z",
                        Address = GetTestFaireAddress(),
                        Items = GetTestFaireItems()
                    }
                });

            _baselinkerApiMock.Setup(p => p.GetOrders(It.IsAny<GetOrdersRequest>(), It.IsAny<string>()))
                .ReturnsAsync(new GetOrdersResponse
                {
                    Status = "SUCCESS",
                    Orders = new List<BaselinkerModels.Order>
                    {
                        new BaselinkerModels.Order
                        {
                            ExtraField1 = "testId1"
                        },
                        new BaselinkerModels.Order
                        {
                            ExtraField1 = "testId3"
                        }
                    }
                });

            _baselinkerApiMock.Setup(p => p.AddOrder(It.IsAny<AddOrderRequest>(), It.IsAny<string>()))
                .ReturnsAsync(GetSuccessBaselinkerAddOrderResponse());

            // Act
            await _transferFaireOrdersToBaselinker.Run(default(TimerInfo), _mockLogger.Object);

            // Assert
            _faireApiMock.Verify(p => p.GetAllOrders(It.IsAny<string>()), Times.Once());
            _baselinkerApiMock.Verify(p => p.GetOrders(It.IsAny<GetOrdersRequest>(), It.IsAny<string>()), Times.Once());
            _baselinkerApiMock.Verify(p => p.AddOrder(It.IsAny<AddOrderRequest>(), It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task TransferFaireOrdersToBaselinker_Should_TransferNoOrders_When_FaireApiReturnsEmptyListOfOrders()
        {
            // Arrange
            _faireApiMock.Setup(p => p.GetAllOrders(It.IsAny<string>()))
                .ReturnsAsync(new List<FaireModels.Order>());

            // Act
            await _transferFaireOrdersToBaselinker.Run(default(TimerInfo), _mockLogger.Object);

            // Assert
            _faireApiMock.Verify(p => p.GetAllOrders(It.IsAny<string>()), Times.Once());
            _baselinkerApiMock.Verify(p => p.AddOrder(It.IsAny<AddOrderRequest>(), It.IsAny<string>()), Times.Never());
        }

        private AddOrderResponse GetSuccessBaselinkerAddOrderResponse()
            => new AddOrderResponse
            {
                Status = "SUCCESS"
            };

        private FaireModels.Address GetTestFaireAddress()
            => new FaireModels.Address
            {
                Address1 = "testAddr1",
                Address2 = "testAddr2",
                PostalCode = "testPostalCode",
                City = "testCity",
                State = "testState",
                CountryCode = "testCountryCode",
                CompanyName = "testCompanyName",
                Name = "testName",
                PhoneNumber = "testPhoneNumber"
            };

        private List<FaireModels.Item> GetTestFaireItems()
            => new List<FaireModels.Item>
                {
                    new FaireModels.Item
                    {
                        Quantity = 1,
                        Sku = "testSku",
                        PriceCents = 1000,
                        ProductName = "testName"
                    }
                };
    }
}