using DemoApp.Model;

namespace DemoApp.Services
{
    public class WeatherService
    {
       
        public double CalculateAverageTemperature(List<WeatherForecast> records)
        {
            if (records == null || !records.Any())
                throw new ArgumentException("No records provided");

            return records.Average(r => r.TemperatureC);
        }

        public string GetHottestCity(List<WeatherForecast> records)
        {
            if (records == null || !records.Any())
                throw new ArgumentException("No records provided");

            return records.OrderByDescending(r => r.TemperatureC).First().Summary ;
        }

        
        public string GetColdestCity(List<WeatherForecast> records)
        {
            if (records == null || !records.Any())
                throw new ArgumentException("No records provided");

            return records.OrderBy(r => r.TemperatureC).First().Summary;
        }
    }
}
