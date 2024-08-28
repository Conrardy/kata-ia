using TrainOffice.Configuration;
using TrainOffice.Data;
using TrainOffice.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;

builder.Services.AddPersistences(configuration);
builder.Services.AddApplications();
builder.Services.AddControllers();

var app = builder.Build();

SeedInMemoryDb(configuration, app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.MapGet(
    "/",
    async context =>
    {
        await context.Response.SendFileAsync("src/index.html");
    }
);

app.Run();

static void AddTestData(ApplicationDbContext context)
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

static void SeedInMemoryDb(ConfigurationManager configuration, WebApplication app)
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