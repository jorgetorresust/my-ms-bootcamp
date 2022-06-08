using Microsoft.AspNetCore.Mvc.Testing;
using System;
using Xunit;
using boot_camp2;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Tests
{
    public class LocationTest{
        [Fact]
    public async Task getAllLocations()
    {
            var application = new WebApplicationFactory<Program>().
                WithWebHostBuilder(builder =>
                {
                    // builder.ConfigureTestServices(services =>
                    //{
                    //    services.AddScoped<ILogger, Class1>();
                    //});
                });

          
            // Arrange
            var client = application.CreateClient();

            // Act
            var response = await client.GetAsync("/api/Location/all/1234");

            // Assert
            response.EnsureSuccessStatusCode();
        }
}
}