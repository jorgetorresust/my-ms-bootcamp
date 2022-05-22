using BL;
using DL;
using Entities;
using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ILocationBL,LocationBL>();
builder.Services.AddSingleton<ILocationDL, LocationDL>();
var app = builder.Build();


app.MapGet("/location/{patientId}", async (ILocationBL _locationBL,String patientId) => {
    return await _locationBL.getLocationsByPatientId(patientId);
});
app.MapGet("/location/", async (ILocationBL _locationBL) => { 
    return await _locationBL.getAllLocations();
});
app.MapGet("/location/", async ([FromQuery(Name ="city")] String city,ILocationBL _locationBL) =>
{
    await _locationBL.getLocationsByCity(city);
});
app.MapPost("/location/", async (ILocationBL _locationBL,Location newLocation) => {
    return await _locationBL.addNewLocation(newLocation);
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.Run();
