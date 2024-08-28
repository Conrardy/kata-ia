using Microsoft.EntityFrameworkCore;
using TrainOffice.Data;
using TrainOffice.Models;

namespace TrainOffice.Configuration;

public static class ConfigureData
{
    public static void SeedInMemoryDb(this WebApplication app, IConfiguration configuration)
    {
        var databaseProvider = configuration.GetValue<string>("DatabaseProvider");
        if (databaseProvider == ConfigurePersistences.InMemoryDb)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();
            AddTestData(context);
        }
    }

    public static void MigrateDatabase(this WebApplication app, IConfiguration configuration)
    {
        var databaseProvider = configuration.GetValue<string>("DatabaseProvider");
        if (databaseProvider == ConfigurePersistences.PostgerSQL)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();
            context.Database.Migrate();
        }
    }

    private static void AddTestData(ApplicationDbContext context)
    {
        var summaries = new List<Summary>
        {
            new() { Content = "Mild" },
            new() { Content = "Hot" },
            new() { Content = "Cold" },
            new() { Content = "Warm" },
            new() { Content = "Freezing" },
            new() { Content = "Cool" },
        };

        context.Summaries.AddRange(summaries);
        context.SaveChanges();
    }
}