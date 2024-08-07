namespace TrainReservationAPI.Dto;
public class Train
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Wagon> Wagons { get; set; }
}