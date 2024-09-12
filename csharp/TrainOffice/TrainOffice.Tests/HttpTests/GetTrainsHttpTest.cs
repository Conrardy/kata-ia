namespace TrainOffice.Tests.HttpTests;

using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Http.Json;
using TrainOffice.Features.Trains;
using TrainOffice.Infrastructures.Models;
using Xunit;

public class GetTrainsHttpTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> factory;
    private readonly LinkGenerator linkGenerator;

    public GetTrainsHttpTest(WebApplicationFactory<Program> factory)
    {
        this.factory = factory;
        this.linkGenerator = factory.Services.GetRequiredService<LinkGenerator>();
    }

    [Fact]
    public async Task GetTrains_ReturnsOkResponse()
    {
        // Arrange
        var client = factory.CreateClient();
        var url = linkGenerator.GetPathByName("GetTrains", values: null);

        // Act
        var response = await client.GetAsync(url);

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<IEnumerable<GetTrainsDTO>>>();
        Assert.NotNull(apiResponse);
        Assert.NotNull(apiResponse.Data);
        Assert.NotEmpty(apiResponse.Data);
        Assert.All(apiResponse.Data, train =>
        {
            Assert.NotNull(train.Name);
        });
    }
}