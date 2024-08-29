using TrainOffice.Features.WeatherForecast.UseCases;

namespace TrainOffice.Configuration;

public static class ConfigureApplications
{
    public static void AddApplications(this IServiceCollection services)
    {
        services.AddScoped<IGetWeatherForecast, GetWeatherForecast>();
    }
}