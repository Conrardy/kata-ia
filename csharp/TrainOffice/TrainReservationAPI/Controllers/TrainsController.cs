using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using TrainReservationAPI.Dto;
using TrainReservationAPI.Services;

namespace TrainReservationAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TrainsController : ControllerBase
{
    // GET: api/trains
    [HttpGet]
    public ActionResult<IEnumerable<Train>> GetTrains()
    {
        var trains = TrainDataStore.Instance.GetTrains();
        return Ok(trains.Select(t => new { t.Id, t.Name }));
    }
}
