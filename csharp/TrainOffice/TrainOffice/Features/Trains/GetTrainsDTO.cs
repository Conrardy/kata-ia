namespace TrainOffice.Features.Trains;

public class GetTrainsDTO
{
    public string Name { get; set; } = string.Empty;
    public string Departure { get; set; } = string.Empty;
    public string Arrival { get; set; } = string.Empty;
    public List<CoachDTO> Coaches { get; set; } = new();
}

public class CoachDTO
{
    public string Name { get; set; } = string.Empty;
    public List<SeatDTO> Seats { get; set; } = new();
}

public class SeatDTO
{
    public string Name { get; set; } = string.Empty;
    public bool Reserved { get; set; }
}