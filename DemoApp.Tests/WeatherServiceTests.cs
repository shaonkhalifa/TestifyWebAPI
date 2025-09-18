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
            Assert.Equal(30, avg);
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

        [Theory]
        [InlineData(20, "Mild", 5, "Freezing", 15, "Cool", "Freezing")]
        [InlineData(30, "Warm", 25, "Pleasant", 40, "Hot", "Pleasant")]
        [InlineData(10, "Chilly", 10, "Frosty", 10, "Cold", "Chilly")] 
        public void GetColdestCity_ShouldReturnLowestTemperatureSummary(int temp1, string summary1, int temp2, string summary2,int temp3, string summary3, string expected)
        {

            var records = new List<WeatherForecast>
            {
                new WeatherForecast { TemperatureC = temp1, Summary = summary1 },
                new WeatherForecast { TemperatureC = temp2, Summary = summary2 },
                new WeatherForecast { TemperatureC = temp3, Summary = summary3 }
            };


            string coldest = _service.GetColdestCity(records);

            Assert.Equal(expected, coldest);
        }

    }
}
