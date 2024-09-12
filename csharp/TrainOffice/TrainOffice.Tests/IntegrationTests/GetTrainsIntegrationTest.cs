namespace TrainOffice.Tests.IntegrationTests;

using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using TrainOffice.Features.Domain;
using TrainOffice.Features.Trains.UseCases;
using TrainOffice.Infrastructures.Memory.Repositories;
using Xunit;

public class GetTrainsIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> factory;

    public GetTrainsIntegrationTest(WebApplicationFactory<Program> factory)
    {
        this.factory = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<ITrainRepository, TrainMemoryRepository>();
                services.AddScoped<ICoachRepository, CoachMemoryRepository>();
                services.AddScoped<ISeatRepository, SeatMemoryRepository>();
            });
        });
    }

    [Fact]
    public async Task GetTrains_UseCase_ReturnsTrains()
    {
        // Arrange
        var scopeFactory = factory.Services.GetRequiredService<IServiceScopeFactory>();
        using var scope = scopeFactory.CreateScope();
        var useCase = scope.ServiceProvider.GetRequiredService<IGetTrainsUseCase>();

        // Act
        var result = await useCase.ExecuteAsync();

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.All(result, train =>
        {
            Assert.NotNull(train.Name);
            Assert.True(train.Coaches != null && train.Coaches.All(coach =>
                coach.Seats != null && coach.Seats.All(seat => seat.Name != null)));
        });
    }
}