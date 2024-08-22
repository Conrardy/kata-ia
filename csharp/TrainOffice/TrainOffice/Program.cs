using Microsoft.EntityFrameworkCore;
using System.Text;
using TrainOffice.Data;
using TrainOffice.Models;
using TrainOffice.Repositories;
using TrainOffice.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var databaseProvider = builder.Configuration.GetValue<string>("DatabaseProvider");

if (databaseProvider == "PostgreSql")
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlConnection"))
    );
    builder.Services.AddScoped<ISummaryRepository, SummaryRepository>();
}
else if (databaseProvider == "InMemory")
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseInMemoryDatabase("InMemoryDb")
    );
    builder.Services.AddScoped<ISummaryRepository, SummaryRepository>();
}
else
{
    builder.Services.AddScoped<ISummaryRepository, SummaryMemoryRepository>();
}

builder.Services.AddScoped<SummaryService>();

var app = builder.Build();

if (databaseProvider == "InMemory")
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();
    AddTestData(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGet(
    "/",
    async context =>
    {
        await context.Response.SendFileAsync("src/index.html");
    }
);
app.MapGet(
        "/weatherforecast",
        async (SummaryService summaryService) =>
        {
            var summaries = await summaryService.GetSummariesAsync();
            var summariesArray = summaries.Select(s => s.Content).ToArray();
            var forecast = Enumerable
                .Range(1, 5)
                .Select(index => new WeatherForecast(
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summariesArray[Random.Shared.Next(summariesArray.Length)]
                ))
                .ToArray();

            var html = new StringBuilder();
            foreach (var weather in forecast)
            {
                html.AppendLine("<tr>");
                html.AppendLine($"<td>{weather.Date}</td>");
                html.AppendLine($"<td>{weather.TemperatureC}</td>");
                html.AppendLine($"<td>{weather.TemperatureF}</td>");
                html.AppendLine($"<td>{weather.Summary}</td>");
                html.AppendLine("</tr>");
            }

            return Results.Content(html.ToString(), "text/html");
        }
    )
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();

static void AddTestData(ApplicationDbContext context)
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

    context.Summaries.AddRange(summaries);
    context.SaveChanges();
}

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}