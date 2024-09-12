using Microsoft.AspNetCore.Mvc;
using TrainOffice.Features.WeatherForecasts.UseCases;
using TrainOffice.Infrastructures.Models;

namespace TrainOffice.Features.WeatherForecasts.Presentation;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController(IGetWeatherForecast weatherForecastApplication) : ControllerBase
{
    /// <summary>
    /// Gets the weather forecast
    /// </summary>
    /// <returns>An array of WeatherForecast entities.</returns>
    [HttpGet(Name = "GetWeatherForecast")]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<WeatherForecast>>), 200)]
    [ProducesResponseType(typeof(ApiResponse<ErrorResponse>), 404)]
    [ProducesResponseType(typeof(ApiResponse<ErrorResponse>), 500)]
    public async Task<IActionResult> GetWeatherForecast()
    {
        var forecast = await weatherForecastApplication.GetWeatherForecastAsync();

        if (forecast == null || forecast.Length == 0)
        {
            return NotFound("WeatherForecast not found");
        }

        return Ok(forecast);
    }
}