using Microsoft.AspNetCore.Mvc.Testing;
using System;
using Xunit;
using boot_camp2;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Tests
{
    public class LocationTest: IClassFixture<WebApplicationFactory<Program>>{ 
    public async Task HelloWorldTest()
    {
        var application = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
            // ... Configure test services
            });
            //
            // Arrange
            var client = application.CreateClient();

            // Act
            var response = await client.GetAsync("/api/Location/u");

            // Assert
            response.Equals(false);
        }
}
}