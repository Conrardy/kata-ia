using Microsoft.EntityFrameworkCore;
using TrainOffice.Data;
using TrainOffice.Models;

namespace TrainOffice.Repositories;

public class SummaryRepository(ApplicationDbContext context) : ISummaryRepository
{
    public async Task<IEnumerable<Summary>> GetSummariesAsync()
    {
        return await context.Summaries.ToListAsync();
    }
}