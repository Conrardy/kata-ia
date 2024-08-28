using TrainOffice.Repositories;

namespace TrainOffice.WeatherForecast;

public interface IWeatherForecastApplication
{
    Task<WeatherForecast[]> GetWeatherForecastAsync();
}

public class WeatherForecastApplication(ISummaryRepository summaryRepository) : IWeatherForecastApplication
{
    public async Task<WeatherForecast[]> GetWeatherForecastAsync()
    {
        var summaries = await summaryRepository.GetSummariesAsync();
        var summariesArray = summaries.Select(s => s.Content).ToArray();
        var forecast = Enumerable
            .Range(1, 5)
            .Select(index => new WeatherForecast(
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summariesArray[Random.Shared.Next(summariesArray.Length)]
            ))
            .ToArray();

        return forecast;
    }
}

public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}