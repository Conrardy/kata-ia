using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TrainReservationAPI.Dto;
using TrainReservationAPI.Services;

namespace TrainReservationAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservationsController : ControllerBase
{
    private static int _reservationIdCounter = 1;
    private static List<Reservation> _reservations = new List<Reservation>();

    // POST: api/reservations
    [HttpPost]
    public ActionResult CreateReservation([FromBody] ReservationRequest request)
    {
        var train = TrainDataStore.Instance.GetTrainById(request.TrainId);

        if (train == null)
        {
            return NotFound(new { message = "Train not found" });
        }

        int totalSeats = train.Wagons.Sum(w => w.Seats.Count);
        int reservedSeatsCount = train.Wagons.Sum(w => w.Seats.Count(s => s.IsReserved));
        int availableSeatsCount = totalSeats - reservedSeatsCount;

        if (request.PassengerCount > availableSeatsCount * 0.3)
        {
            return BadRequest(new { message = "Cannot reserve more than 70% of the total seats" });
        }

        var reservedSeats = new List<string>();
        foreach (var wagon in train.Wagons)
        {
            var availableSeats = wagon.Seats.Where(s => !s.IsReserved).Take(request.PassengerCount - reservedSeats.Count);
            foreach (var seat in availableSeats)
            {
                seat.IsReserved = true;
                reservedSeats.Add(seat.SeatNumber);
            }
            if (reservedSeats.Count >= request.PassengerCount)
            {
                break;
            }
        }

        if (reservedSeats.Count < request.PassengerCount)
        {
            return BadRequest(new { message = "Not enough seats available" });
        }

        var reservation = new Reservation
        {
            Id = _reservationIdCounter++,
            TrainId = request.TrainId,
            ReservedSeats = reservedSeats,
            CreatedAt = DateTime.UtcNow
        };

        _reservations.Add(reservation);

        return Ok(new
        {
            ReservationId = reservation.Id,
            ReservedSeats = reservedSeats
        });
    }
}

public class ReservationRequest
{
    public int TrainId { get; set; }
    public int PassengerCount { get; set; }
}
