namespace TrainOffice.Features.Trains.Presentation;

using Microsoft.AspNetCore.Mvc;
using TrainOffice.Features.Trains.UseCases;
using TrainOffice.Infrastructures.Models;

[ApiController]
[Route("api/[controller]")]
public class TrainsController(IGetTrainsUseCase getTrainsUseCase) : ControllerBase
{
    [HttpGet(Name = "GetTrains")]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<GetTrainsDTO>>), 200)]
    [ProducesResponseType(typeof(ApiResponse<ErrorResponse>), 404)]
    [ProducesResponseType(typeof(ApiResponse<ErrorResponse>), 500)]
    public async Task<IActionResult> GetTrains()
    {
        var result = await getTrainsUseCase.ExecuteAsync();

        return Ok(result);
    }
}