using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainOffice.Data;
using TrainOffice.Models;

namespace TrainOffice.Repositories
{
    public class SummaryMemoryRepository : ISummaryRepository
    {
        public async Task<IEnumerable<Summary>> GetSummariesAsync()
        {
            var summaries = new List<Summary>
            {
                new Summary { Content = "Mild" },
                new Summary { Content = "Hot" },
                new Summary { Content = "Cold" },
                new Summary { Content = "Warm" },
                new Summary { Content = "Freezing" },
                new Summary { Content = "Cool" },
            };

            return await Task.FromResult(summaries);
        }
    }
}
