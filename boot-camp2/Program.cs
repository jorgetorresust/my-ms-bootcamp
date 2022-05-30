using Dal;
using Serilog;
using Services;

var builder = WebApplication.CreateBuilder(args);
//var log = new LoggerConfiguration()
//    .WriteTo.File("C:\\Users\\user\\source\\Repos\\nessi0527\\logs\\logFile.txt")
//    .CreateLogger();
//    log.Information("Hello, Serilog!");
//    log.Warning("Goodbye, Serilog.");
//Log.Logger = new LoggerConfiguration()
//    .MinimumLevel.Debug()
//    .WriteTo.File("log.txt")
//    .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)
//    .CreateLogger();
//builder.Host.UseSerilog();
//var logger = new LoggerConfiguration()
//  .ReadFrom.Configuration(builder.Configuration)
//  .Enrich.FromLogContext()
//  .CreateLogger();
//builder.Logging.ClearProviders();
//builder.Logging.AddSerilog(logger);
builder.Services.AddRazorPages();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<ILocationData, LocationData>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();

app.Run();
public partial class Program { }