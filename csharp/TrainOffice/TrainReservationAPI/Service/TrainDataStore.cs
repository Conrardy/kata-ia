namespace TrainReservationAPI.Service;

public class TrainDataStore
{
    private static readonly TrainDataStore _instance = new TrainDataStore();
    private List<Train> _trains;

    private TrainDataStore()
    {
        _trains = new List<Train>
        {
            new Train
            {
                Id = 1,
                Name = "Train Alpha",
                Wagons = new List<Wagon>
                {
                    new Wagon
                    {
                        Id = 1,
                        Letter = 'A',
                        Seats = Enumerable.Range(1, 20).Select(i => new Seat
                        {
                            SeatNumber = $"{i}A",
                            IsReserved = false
                        }).ToList()
                    },
                    new Wagon
                    {
                        Id = 2,
                        Letter = 'B',
                        Seats = Enumerable.Range(1, 25).Select(i => new Seat
                        {
                            SeatNumber = $"{i}B",
                            IsReserved = false
                        }).ToList()
                    }
                }
            },
            new Train
            {
                Id = 2,
                Name = "Train Beta",
                Wagons = new List<Wagon>
                {
                    new Wagon
                    {
                        Id = 1,
                        Letter = 'A',
                        Seats = Enumerable.Range(1, 30).Select(i => new Seat
                        {
                            SeatNumber = $"{i}A",
                            IsReserved = false
                        }).ToList()
                    },
                    new Wagon
                    {
                        Id = 2,
                        Letter = 'B',
                        Seats = Enumerable.Range(1, 30).Select(i => new Seat
                        {
                            SeatNumber = $"{i}B",
                            IsReserved = false
                        }).ToList()
                    }
                }
            }
        };
    }

    public static TrainDataStore Instance => _instance;

    public List<Train> GetTrains()
    {
        return _trains;
    }

    public Train GetTrainById(int id)
    {
        return _trains.FirstOrDefault(t => t.Id == id);
    }

    public void AddReservation(Reservation reservation)
    {
        // Logic to add a reservation could go here, if needed.
    }
}
