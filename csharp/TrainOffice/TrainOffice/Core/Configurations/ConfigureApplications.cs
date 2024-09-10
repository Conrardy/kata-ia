using TrainOffice.Features.WeatherForecasts.UseCases;

namespace TrainOffice.Core.Configuration;

public static class ConfigureApplications
{
    public static void AddApplications(this IServiceCollection services)
    {
        services.AddScoped<IGetWeatherForecast, GetWeatherForecast>();
    }
}