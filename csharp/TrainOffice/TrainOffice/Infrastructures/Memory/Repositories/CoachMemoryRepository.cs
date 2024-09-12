namespace TrainOffice.Infrastructures.Memory.Repositories;

using TrainOffice.Features.Domain;
using TrainOffice.Infrastructures.Models;

public class CoachMemoryRepository : ICoachRepository
{
    private readonly List<Coach> _coaches = new()
    {
        new Coach { Id = 1, TrainId = 1, Name = "Coach A" },
        new Coach { Id = 2, TrainId = 1, Name = "Coach B" },
        new Coach { Id = 3, TrainId = 2, Name = "Coach A" },
        // Add more fake data
    };

    public Task<IEnumerable<Coach>> GetAllAsync()
    {
        return Task.FromResult(_coaches.AsEnumerable());
    }
}
