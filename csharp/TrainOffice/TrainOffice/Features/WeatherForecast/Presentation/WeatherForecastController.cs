using Microsoft.AspNetCore.Mvc;
using System.Text;
using TrainOffice.Features.WeatherForecast.UseCases;

namespace TrainOffice.Features.WeatherForecast.Presentation;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(IGetWeatherForecast weatherForecastApplication) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetWeatherForecast()
    {
        var forecast = await weatherForecastApplication.GetWeatherForecastAsync();

        var html = new StringBuilder();
        foreach (var weather in forecast)
        {
            html.AppendLine("<tr>");
            html.AppendLine($"<td>{weather.Date}</td>");
            html.AppendLine($"<td>{weather.TemperatureC}</td>");
            html.AppendLine($"<td>{weather.TemperatureF}</td>");
            html.AppendLine($"<td>{weather.Summary}</td>");
            html.AppendLine("</tr>");
        }

        return Content(html.ToString(), "text/html");
    }
}