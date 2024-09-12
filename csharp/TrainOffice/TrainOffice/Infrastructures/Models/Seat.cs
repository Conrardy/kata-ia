namespace TrainOffice.Infrastructures.Models;

public class Seat
{
    public int Id { get; set; }
    public int CoachId { get; set; }
    public string Name { get; set; }
    public bool IsReserved { get; set; }
}
