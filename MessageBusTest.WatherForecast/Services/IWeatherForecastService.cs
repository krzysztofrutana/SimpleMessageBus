using MessageBusTest.Data;

namespace MessageBusTest.WatherForecast.Services
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> GetWatherForecast();
    }
}
