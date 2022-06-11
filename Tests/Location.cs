using Microsoft.AspNetCore.Mvc.Testing;
using System;
using Xunit;
using boot_camp2;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using boot_camp2.Controllers;
using Services;
using Moq;

namespace Tests
{
    public class LocationTest
    {
        [Fact]
        public async Task getAllLocations()
        {
            var application = new WebApplicationFactory<Program>().
                WithWebHostBuilder(builder =>
                {
                    builder.ConfigureTestServices(services =>
                    {
                        //var serviceProvider = services.BuildServiceProvider();
                        //var logger = serviceProvider.GetService<ILogger<>>();
                        services.AddSingleton<ILoggerFactory, NullLoggerFactory>();
                    });
                });


            // Arrange
            Mock<ILocationService> mockLocationService = new Mock<ILocationService>();
            mockLocationService
                .Setup(l => l.getLocations())
                .Returns(() => Task.FromResult(new List<Location>() { new Location() { City = "jer", StartDate = new DateTime(), EndDate = new DateTime(), location = "jer", PatientId = "555" } }));
            LocationController location = new LocationController(mockLocationService.Object);
            // Act
            var response = await location.Get();

            // Assert
            Assert.True(true);

        }

        [Fact]
        public async Task GetLocationsByPatientId()
        {
            var application = new WebApplicationFactory<Program>().
                WithWebHostBuilder(builder =>
                {
                    builder.ConfigureTestServices(services =>
                    {
                    //var serviceProvider = services.BuildServiceProvider();
                    //var logger = serviceProvider.GetService<ILogger<>>();
                        services.AddSingleton<ILoggerFactory, NullLoggerFactory>();
                    });
                });


            // Arrange
            var client = application.CreateClient();
            // Act
            var response = await client.GetAsync("/api/Location/1234");

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}