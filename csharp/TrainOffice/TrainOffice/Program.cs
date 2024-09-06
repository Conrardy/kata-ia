using TrainOffice.Core.Configuration;
using TrainOffice.Core.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;

builder.Services.AddPersistences(configuration);
builder.Services.AddApplications();
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.SeedInMemoryDb(configuration);
app.MigrateDatabase(configuration);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

// use to serve static files like app.js
app.UseStaticFiles();

app.UseCustomMiddlewares();

app.MapControllers();

app.MapGet(
    "/",
    async context =>
    {
        await context.Response.SendFileAsync("pages/index.html");
    }
);

app.Run();

// needed for use WebApplicationFactory in http tests
public partial class Program
{ }