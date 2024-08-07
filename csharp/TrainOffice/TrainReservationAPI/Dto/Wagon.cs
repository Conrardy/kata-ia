namespace TrainReservationAPI.Dto;
public class Wagon
{
    public int Id { get; set; }
    public char Letter { get; set; }
    public List<Seat> Seats { get; set; }
}
