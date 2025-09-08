using DemoApp.Model;

namespace DemoApp.Services
{
    public class WeatherService
    {
        public double CalculateAverageTemperature(List<WeatherRecord> records)
        {
            if (records == null || records.Count == 0)
                throw new ArgumentException("No weather records provided");

            return records.Average(r => r.TemperatureCelsius);
        }

        public string GetHottestCity(List<WeatherRecord> records)
        {
            if (records == null || records.Count == 0)
                throw new ArgumentException("No weather records provided");

            return records.OrderByDescending(r => r.TemperatureCelsius).First().City;
        }

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
    }
}
