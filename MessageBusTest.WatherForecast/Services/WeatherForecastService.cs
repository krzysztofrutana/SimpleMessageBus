using MessageBusTest.Data;
using MessageBusTest.Data.Models;

namespace MessageBusTest.WatherForecast.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        public IEnumerable<WeatherForecast> GetWatherForecast()
        {
            var summaries = new Sumaries();

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries.Summaries[Random.Shared.Next(summaries.Summaries.Length)]
            })
            .ToArray();
        }
    }
}
