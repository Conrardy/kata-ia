using TrainOffice.WeatherForecast;

namespace TrainOffice.Configuration;

public static class ConfigureApplications
{
    public static void AddApplications(this IServiceCollection services)
    {
        services.AddScoped<IWeatherForecastApplication, WeatherForecastApplication>();
    }
}