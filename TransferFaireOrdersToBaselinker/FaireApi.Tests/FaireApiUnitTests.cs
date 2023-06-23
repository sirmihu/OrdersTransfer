using FaireApi.Models;
using FaireApi.Settings;
using Microsoft.Extensions.Options;
using Moq;
using Newtonsoft.Json;
using RestSharp;
using Xunit;

namespace FaireApi.Tests;

public class FaireApiTests
{
    private readonly FaireApi _faireApi;
    private readonly Mock<RestClient> _restClientMock;
    private readonly Mock<IOptions<FaireApiSettings>> _mockOptions;
    private readonly Mock<IRestClient> _mockRestClient;

    public FaireApiTests()
    {
        _restClientMock = new Mock<RestClient>();
        _mockOptions = new Mock<IOptions<FaireApiSettings>>();
        _mockOptions.Setup(p => p.Value).Returns(new FaireApiSettings { BaseApiAddressUrl = "testAddressUrl", Token = "testToken" });
        
        _faireApi = new FaireApi(_mockRestClient.Object, _mockOptions.Object);
    }

    [Theory]
    [InlineData("TestData/FaireGetAllOrdersResponse.json")]
    public async Task GetAllOrders_Should_Return_ListOf2Orders(string filePath)
    {
        // Arrange
        var testOrders = PrepareTestFaireOrders(filePath);
        _mockRestClient.Setup(p => p.GetAsync<IEnumerable<Order>>(It.IsAny<RestRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(testOrders);

        // Act
        var allOrders = await _faireApi.GetAllOrders();

        // Assert
        Assert.NotEmpty(allOrders);
        Assert.Equal(testOrders.Count(), allOrders.Count());
    }

    private IEnumerable<Order> PrepareTestFaireOrders(string path)
    {
        var fileContent = File.ReadAllText(Path.Combine(Path.GetFullPath(Directory.GetCurrentDirectory()), "..\\..\\..", path));
        return JsonConvert.DeserializeObject<IEnumerable<Order>>(fileContent);
    }
}

