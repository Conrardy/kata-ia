using TrainOffice.Features.WeatherForecasts.UseCases;

namespace TrainOffice.Tests.Unit;

public class UnitTest
{
    [Fact]
    public void TestWeatherForecastProperties()
    {
        // Arrange
        var date = DateOnly.FromDateTime(DateTime.Now);
        var temperatureC = 25;
        var summary = "Sunny";

        // Act
        var weatherForecast = new WeatherForecast(date, temperatureC, summary);

        // Assert
        Assert.Equal(date, weatherForecast.Date);
        Assert.Equal(temperatureC, weatherForecast.TemperatureC);
        Assert.Equal(summary, weatherForecast.Summary);
        Assert.True(weatherForecast.TemperatureF > 32);
    }
}