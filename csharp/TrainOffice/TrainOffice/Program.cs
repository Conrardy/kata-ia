using TrainOffice.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;

builder.Services.AddPersistences(configuration);
builder.Services.AddApplications();
builder.Services.AddControllers();

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
app.MapControllers();

app.MapGet(
    "/",
    async context =>
    {
        await context.Response.SendFileAsync("Src/index.html");
    }
);

app.Run();