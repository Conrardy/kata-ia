using TrainOffice.Features.Domain;
using TrainOffice.Infrastructures.Models;

namespace TrainOffice.Infrastructures.Memory.Repositories;

public class SummaryMemoryRepository : ISummaryRepository
{
    public async Task<IEnumerable<Summary>> GetSummariesAsync()
    {
        var summaries = new List<Summary>
        {
            new() { Content = "Mild" },
            new() { Content = "Hot" },
            new() { Content = "Cold" },
            new() { Content = "Warm" },
            new() { Content = "Freezing" },
            new() { Content = "Cool" },
        };

        return await Task.FromResult(summaries);
    }
}