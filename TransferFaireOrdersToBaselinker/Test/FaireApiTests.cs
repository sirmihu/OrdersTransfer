using FaireApi.Exceptions;
using FaireApi.Models;
using FaireApi.Responses;
using FaireApi.Settings;
using FaireApi.Utils;
using Microsoft.Extensions.Options;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace FaireApi.Tests;

public class FaireApiTests
{
    private readonly FaireApi _faireApi;
    private readonly Mock<IOptions<FaireApiSettings>> _mockOptions;
    private readonly Mock<IFaireApiHttpClient> _mockFaireApiHttpClient;
    private readonly int _maxOrdersLimitPerPage;
    private readonly string _token;

    public FaireApiTests()
    {
        _token = "testToken";
        _mockFaireApiHttpClient = new Mock<IFaireApiHttpClient>();
        _mockOptions = new Mock<IOptions<FaireApiSettings>>();
        _mockOptions.Setup(p => p.Value).Returns(new FaireApiSettings { Token = _token });
        _maxOrdersLimitPerPage = 50;

        _faireApi = new FaireApi(_mockFaireApiHttpClient.Object);
    }

    [Theory]
    [InlineData("TestData/FaireGetAllOrdersReturns2Orders.json")]
    public async Task GetAllOrders_Should_Return_ListOf2Orders(string filePath)
    {
        // Arrange
        var testOrders = PrepareTestGetAllOrdersResponse(filePath);
        _mockFaireApiHttpClient.Setup(p => p.GetAsync<GetAllOrdersResponse>(It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync(testOrders);

        // Act
        var allOrders = await _faireApi.GetAllOrders(_token);

        // Assert
        Assert.NotEmpty(allOrders);
        Assert.Equal(testOrders.Orders?.Count(), allOrders.Count());
    }

    [Theory]
    [InlineData("TestData/FaireGetAllOrdersReturnsMaxNumberOfOrders.json", "TestData/FaireGetAllOrdersReturns2Orders.json")]
    public async Task GetAllOrders_Should_Return_ListOfCountGreaterThanMaxOrdersPerPage(string firstPageResponsePath, string secondPageResponsePath)
    {
        // Arrange
        var firstPageOrders = PrepareTestGetAllOrdersResponse(firstPageResponsePath);
        var secondPageOrders = PrepareTestGetAllOrdersResponse(secondPageResponsePath);
        var testOrders = firstPageOrders.Orders?.Union(secondPageOrders.Orders);

        var firstPagePath = $"{FaireApiUrl.GetAllOrders}?limit={_maxOrdersLimitPerPage}&page=1";
        var secondPagePath = $"{FaireApiUrl.GetAllOrders}?limit={_maxOrdersLimitPerPage}&page=2";

        _mockFaireApiHttpClient.Setup(p => p.GetAsync<GetAllOrdersResponse>(firstPagePath, _token))
            .ReturnsAsync(firstPageOrders);
        _mockFaireApiHttpClient.Setup(p => p.GetAsync<GetAllOrdersResponse>(secondPagePath, _token))
            .ReturnsAsync(secondPageOrders);

        // Act
        var allOrders = await _faireApi.GetAllOrders(_token);

        // Assert
        Assert.NotEmpty(allOrders);
        Assert.Equal(testOrders?.Count(), allOrders?.Count());
    }

    [Fact]
    public async Task GetAllOrders_Throws_FaireApiException_When_ErrorOnFaireApiSide()
    {
        // Act & Assert
        await Assert.ThrowsAsync<FaireApiException>(async () => await _faireApi.GetAllOrders(_token));
    }

    private GetAllOrdersResponse PrepareTestGetAllOrdersResponse(string filePath)
    {
        var directoryPath = Path.GetFullPath(Directory.GetCurrentDirectory());
        var combinedFilePath = Path.Combine(directoryPath, "../../..", filePath);
        var fileContent = File.ReadAllText(combinedFilePath);

        return JsonConvert.DeserializeObject<GetAllOrdersResponse>(fileContent);     
    }
}