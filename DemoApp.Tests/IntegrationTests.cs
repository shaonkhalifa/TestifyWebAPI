using DemoApp;
using DemoApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Json;
using Xunit;

namespace DemoApp.Tests.IntegrationTests
{
    public class WeatherForecastIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public WeatherForecastIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetWeatherForecast_Returns5Items()
        {
            var result = await _client.GetFromJsonAsync<WeatherForecast[]>("/WeatherForecast");

            Assert.NotNull(result);
            Assert.Equal(5, result.Length);
        }
    }
}
