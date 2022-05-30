using Microsoft.AspNetCore.Mvc.Testing;
using System;
using Xunit;
using boot_camp2;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Tests
{
    //: IClassFixture<WebApplicationFactory<Program>>
    public class LocationTest{
        [Fact]
    public async Task test_getAllLocations()
    {
            var application = new WebApplicationFactory<Program>();
          
            // Arrange
            var client = application.CreateClient();

            // Act
            var response = await client.GetAsync("/api/Location/all");

            // Assert
            response.EnsureSuccessStatusCode();
        }
}
}