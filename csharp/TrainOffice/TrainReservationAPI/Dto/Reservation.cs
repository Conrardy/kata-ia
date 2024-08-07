namespace TrainReservationAPI.Dto;
public class Reservation
{
    public int Id { get; set; }
    public int TrainId { get; set; }
    public List<string> ReservedSeats { get; set; }
    public DateTime CreatedAt { get; set; }
}