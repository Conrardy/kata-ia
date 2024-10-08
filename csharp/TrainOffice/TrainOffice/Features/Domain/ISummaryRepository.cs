using TrainOffice.Infrastructures.Models;

namespace TrainOffice.Features.Domain;

public interface ISummaryRepository
{
    Task<IEnumerable<Summary>> GetSummariesAsync();
}