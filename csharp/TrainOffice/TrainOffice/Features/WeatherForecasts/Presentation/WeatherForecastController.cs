using Microsoft.AspNetCore.Mvc;
using System.Text;
using TrainOffice.Features.WeatherForecasts.UseCases;
using TrainOffice.Infrastructures.Models;

namespace TrainOffice.Features.WeatherForecasts.Presentation;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(IGetWeatherForecast weatherForecastApplication) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetWeatherForecastHtml()
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

    /// <summary>
    /// Gets the weather forecast in JSON format.
    /// </summary>
    /// <returns>An array of WeatherForecast entities.</returns>
    [HttpGet("json", Name = "GetWeatherForecastJson")]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<WeatherForecast>>), 200)]
    [ProducesResponseType(typeof(ApiResponse<ErrorResponse>), 404)]
    [ProducesResponseType(typeof(ApiResponse<ErrorResponse>), 500)]
    public async Task<IActionResult> GetWeatherForecastJson()
    {
        var forecast = await weatherForecastApplication.GetWeatherForecastAsync();

        if (forecast == null || forecast.Length == 0)
        {
            return NotFound("WeatherForecast not found");
        }

        return Ok(forecast);
    }
}