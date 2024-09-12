namespace TrainOffice.Core.Configuration;

using TrainOffice.Features.Trains.UseCases;
using TrainOffice.Features.WeatherForecasts.UseCases;

public static class ConfigureApplications
{
    public static void AddApplications(this IServiceCollection services)
    {
        services.AddScoped<IGetWeatherForecast, GetWeatherForecast>();
        services.AddScoped<IGetTrainsUseCase, GetTrainsUseCase>();
    }
}