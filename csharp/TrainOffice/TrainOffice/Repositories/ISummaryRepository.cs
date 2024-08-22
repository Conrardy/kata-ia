using System.Collections.Generic;
using System.Threading.Tasks;
using TrainOffice.Models;

namespace TrainOffice.Repositories
{
    public interface ISummaryRepository
    {
        Task<IEnumerable<Summary>> GetSummariesAsync();
    }
}
