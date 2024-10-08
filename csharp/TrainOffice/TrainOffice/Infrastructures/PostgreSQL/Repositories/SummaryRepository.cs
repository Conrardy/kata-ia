using Microsoft.EntityFrameworkCore;
using TrainOffice.Features.Domain;
using TrainOffice.Infrastructures.Models;
using TrainOffice.Infrastructures.PostgreSQL.Context;

namespace TrainOffice.Infrastructures.PostgreSQL.Repositories;

public class SummaryRepository(ApplicationDbContext context) : ISummaryRepository
{
    public async Task<IEnumerable<Summary>> GetSummariesAsync()
    {
        return await context.Summaries.ToListAsync();
    }
}