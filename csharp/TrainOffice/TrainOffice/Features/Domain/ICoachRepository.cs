using TrainOffice.Infrastructures.Models;

namespace TrainOffice.Features.Domain;

public interface ICoachRepository
{
    Task<IEnumerable<Coach>> GetAllAsync();
}