namespace TrainOffice.Infrastructures.Memory.Repositories;

using TrainOffice.Features.Domain;
using TrainOffice.Infrastructures.Models;

public class SeatMemoryRepository : ISeatRepository
{
    private readonly List<Seat> _seats = new()
    {
        new Seat { Id = 1, CoachId = 1, Name = "1A", IsReserved = true },
        new Seat { Id = 2, CoachId = 1, Name = "2A", IsReserved = false },
        new Seat { Id = 3, CoachId = 1, Name = "3A", IsReserved = false },
        new Seat { Id = 4, CoachId = 1, Name = "4A", IsReserved = true },
        new Seat { Id = 5, CoachId = 1, Name = "5A", IsReserved = true },
        new Seat { Id = 6, CoachId = 1, Name = "6A", IsReserved = false },
        new Seat { Id = 7, CoachId = 1, Name = "7A", IsReserved = false },
        new Seat { Id = 8, CoachId = 1, Name = "8A", IsReserved = true },
        new Seat { Id = 9, CoachId = 1, Name = "9A", IsReserved = true },
        new Seat { Id = 10, CoachId = 1, Name = "10A", IsReserved = false },

        new Seat { Id = 11, CoachId = 2, Name = "1B", IsReserved = false },
        new Seat { Id = 12, CoachId = 2, Name = "2B", IsReserved = false },
        new Seat { Id = 13, CoachId = 2, Name = "3B", IsReserved = true },
        new Seat { Id = 14, CoachId = 2, Name = "4B", IsReserved = true },
        new Seat { Id = 15, CoachId = 2, Name = "5B", IsReserved = true },
        new Seat { Id = 16, CoachId = 2, Name = "6B", IsReserved = false },
        new Seat { Id = 17, CoachId = 2, Name = "7B", IsReserved = false },
        new Seat { Id = 18, CoachId = 2, Name = "8B", IsReserved = false },
        new Seat { Id = 19, CoachId = 2, Name = "9B", IsReserved = false },
        new Seat { Id = 20, CoachId = 2, Name = "10B", IsReserved = false },

        new Seat { Id = 21, CoachId = 3, Name = "1A", IsReserved = false },
        new Seat { Id = 22, CoachId = 3, Name = "2A", IsReserved = false },
        new Seat { Id = 23, CoachId = 3, Name = "3A", IsReserved = true },
        new Seat { Id = 24, CoachId = 3, Name = "4A", IsReserved = true },
        new Seat { Id = 25, CoachId = 3, Name = "5A", IsReserved = true },
        new Seat { Id = 26, CoachId = 3, Name = "6A", IsReserved = false },
        new Seat { Id = 27, CoachId = 3, Name = "7A", IsReserved = false },
        new Seat { Id = 28, CoachId = 3, Name = "8A", IsReserved = false },
        new Seat { Id = 29, CoachId = 3, Name = "9A", IsReserved = false },
        new Seat { Id = 30, CoachId = 3, Name = "10A", IsReserved = false },
        // Add more fake data
    };

    public Task<IEnumerable<Seat>> GetAllAsync()
    {
        return Task.FromResult(_seats.AsEnumerable());
    }
}
