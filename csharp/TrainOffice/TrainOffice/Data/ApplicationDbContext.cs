using Microsoft.EntityFrameworkCore;
using TrainOffice.Models;

namespace TrainOffice.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Summary> Summaries { get; set; }
    }
}
