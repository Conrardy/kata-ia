using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainOffice.Data;
using TrainOffice.Models;

namespace TrainOffice.Repositories
{
    public class SummaryRepository : ISummaryRepository
    {
        private readonly ApplicationDbContext _context;

        public SummaryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Summary>> GetSummariesAsync()
        {
            return await _context.Summaries.ToListAsync();
        }
    }
}
