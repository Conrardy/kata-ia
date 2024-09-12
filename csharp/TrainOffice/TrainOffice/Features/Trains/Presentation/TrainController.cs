namespace TrainOffice.Features.Trains.Presentation;

using Microsoft.AspNetCore.Mvc;
using TrainOffice.Infrastructures.Models;

[ApiController]
[Route("api/[controller]")]
public class TrainsController : ControllerBase
{
    [HttpGet(Name = "GetTrains")]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<GetTrainsDTO>>), 200)]
    [ProducesResponseType(typeof(ApiResponse<ErrorResponse>), 404)]
    [ProducesResponseType(typeof(ApiResponse<ErrorResponse>), 500)]
    public IActionResult GetTrains()
    {
        var trains = new List<GetTrainsDTO>
        {
            new GetTrainsDTO
            {
                Name = "Train 1",
                Departure = "10:00 AM",
                Arrival = "2:00 PM",
                Coaches = new List<CoachDTO>
                {
                    new CoachDTO
                    {
                        Name = "A",
                        Seats = new List<SeatDTO>
                        {
                            new SeatDTO { Name = "A1", Reserved = false },
                            new SeatDTO { Name = "A2", Reserved = true }
                        }
                    }
                }
            }
        };
        return Ok(trains);
    }
}