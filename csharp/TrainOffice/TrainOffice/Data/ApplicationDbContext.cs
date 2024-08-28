using Microsoft.EntityFrameworkCore;
using TrainOffice.Models;

namespace TrainOffice.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Summary> Summaries { get; set; }
}