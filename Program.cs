using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers();

// this is where we connect the connection string
builder.Services.AddDbContext<ApiDbContext>(
    op =>
    op.UseSqlServer("Server=localhost,1433;Database=Webpp1;User Id=sa;Password=Kamsiriochi123@;TrustServerCertificate=True;"
    ));

var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/emeka", () => {
    Dictionary<string, string> response = new() {
        {"name", "Nnaemeka"},
        {"age", "24"},
        {"goal", "to be successiful"}
    };
    return response;
}).WithName("emekas_endpoint");

app.MapGet("/weatherforecast", () => {
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
}).WithName("GetWeatherForecast");

// for the home route
app.MapGet("/", () => {
    Dictionary<string, string> result = new() {
        { "greeting", "Hello, World!" },
        { "status", "active" },
        { "role", "developer" }
    };
    return result;
}).WithName("GetHome");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string Summary) {
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
