using DemoApp.Model;
using DemoApp.Services;
using Xunit;
using System.Collections.Generic;

namespace DemoApp.Tests.ServicesTests
{
    public class WeatherServiceTests
    {
        private readonly WeatherService _service = new WeatherService();

        [Fact]
        public void CalculateAverageTemperature_ShouldReturnCorrectValue()
        {
            var records = new List<WeatherForecast>
            {
                new WeatherForecast { TemperatureC = 20 },
                new WeatherForecast { TemperatureC = 30 },
                new WeatherForecast { TemperatureC = 40 }
            };

            double avg = _service.CalculateAverageTemperature(records);
            Assert.Equal(35, avg);
        }

        [Fact]
        public void GetHottestCity_ShouldReturnHighestTemperature()
        {
            var records = new List<WeatherForecast>
            {
                new WeatherForecast { TemperatureC = 20, Summary="Cold" },
                new WeatherForecast { TemperatureC = 40, Summary="Hot" },
                new WeatherForecast { TemperatureC = 30, Summary="Warm" }
            };

            string hottest = _service.GetHottestCity(records);
            Assert.Equal("Hot", hottest);
        }
    }
}
