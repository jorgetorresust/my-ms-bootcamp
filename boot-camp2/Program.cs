using boot_camp2.Middleware;
using Dal;
using Serilog;
using Services;

var builder = WebApplication.CreateBuilder(args);

//builder.Host.UseSerilog((hostContext, services, configuration) =>
//{
//    configuration.WriteTo.File("C:\\Users\\user\\source\\Repos\\nessi0527\\logs\\log.txt");
//});
var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<ILocationData, LocationData>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
//app.UseErrorHandler();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
public partial class Program { }