namespace TrainOffice.Infrastructures.Memory.Repositories;

using TrainOffice.Features.Domain;
using TrainOffice.Infrastructures.Models;

public class TrainMemoryRepository : ITrainRepository
{
    private readonly List<Train> _trains = new()
    {
        new Train { Id = 1, Name = "Train titi", Departure = "Paris", Arrival = "Marseille" },
        new Train { Id = 2, Name = "Train toto", Departure = "London", Arrival = "Brussel" },
        // Add more fake data
    };

    public Task<IEnumerable<Train>> GetAllAsync()
    {
        return Task.FromResult(_trains.AsEnumerable());
    }
}