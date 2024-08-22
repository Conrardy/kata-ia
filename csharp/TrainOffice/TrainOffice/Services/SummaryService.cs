// Services/SummaryService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using TrainOffice.Models;
using TrainOffice.Repositories;

namespace TrainOffice.Services
{
    public class SummaryService
    {
        private readonly ISummaryRepository _summaryRepository;

        public SummaryService(ISummaryRepository summaryRepository)
        {
            _summaryRepository = summaryRepository;
        }

        public async Task<IEnumerable<Summary>> GetSummariesAsync()
        {
            return await _summaryRepository.GetSummariesAsync();
        }
    }
}