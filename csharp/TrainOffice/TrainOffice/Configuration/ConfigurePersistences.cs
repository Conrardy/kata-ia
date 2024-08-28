using Microsoft.EntityFrameworkCore;
using TrainOffice.Data;
using TrainOffice.Repositories;

namespace TrainOffice.Configuration;

public static class ConfigurePersistences
{
    public static readonly string PostgerSQL = "PostgreSql";
    public static readonly string InMemoryDb = "InMemoryDb";
    public static readonly string InMemory = "InMemory";

    public static void AddPersistences(this IServiceCollection services, ConfigurationManager configuration)
    {
        var databaseProvider = configuration.GetValue<string>("DatabaseProvider");

        ArgumentNullException.ThrowIfNull(databaseProvider);

        if (databaseProvider == PostgerSQL)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("PostgreSqlConnection"))
            );
            services.AddScoped<ISummaryRepository, SummaryRepository>();
        }
        else if (databaseProvider == InMemoryDb)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("InMemoryDb")
            );
            services.AddScoped<ISummaryRepository, SummaryRepository>();
        }
        else if (databaseProvider == InMemory)
        {
            services.AddScoped<ISummaryRepository, SummaryMemoryRepository>();
        }
    }
}