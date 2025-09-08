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
            // Arrange
            var mockLogger = new Mock<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(mockLogger.Object);

           // Act
           var result = controller.Get();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(50, result.Count());
            Assert.All(result, item => Assert.IsType<WeatherForecast>(item));
        }
    }
}
