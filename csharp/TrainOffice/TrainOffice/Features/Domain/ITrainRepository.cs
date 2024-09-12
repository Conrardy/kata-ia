namespace TrainOffice.Features.Domain;

using TrainOffice.Infrastructures.Models;

public interface ITrainRepository
{
    Task<IEnumerable<Train>> GetAllAsync();
}