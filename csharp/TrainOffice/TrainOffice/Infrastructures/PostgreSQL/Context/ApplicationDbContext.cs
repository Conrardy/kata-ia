using Microsoft.EntityFrameworkCore;
using TrainOffice.Infrastructures.Models;

namespace TrainOffice.Infrastructures.PostgreSQL.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Summary> Summaries { get; set; }
}