using TrainOffice.Infrastructures.Models;

namespace TrainOffice.Features.Domain;

public interface ISeatRepository
{
    Task<IEnumerable<Seat>> GetAllAsync();
}