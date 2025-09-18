using DemoApp.Controllers;
using DemoApp.Model;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace DemoApp.Tests.ControllersTests
{
    public class WeatherForecastControllerTests
    {
        [Fact]
        public void Get_ShouldReturnArrayOfWeatherForecast()
        {
 
            var mockLogger = new Mock<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(mockLogger.Object);

   
           var result = controller.Get();

            Assert.NotNull(result);
            Assert.Equal(5, result.Count());
            Assert.All(result, item => Assert.IsType<WeatherForecast>(item));
        }
    }
}
