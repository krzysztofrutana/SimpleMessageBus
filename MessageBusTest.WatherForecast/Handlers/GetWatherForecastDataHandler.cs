using MessageBusTest.Data;
using MessageBusTest.MessageBus.Abstraction;
using MessageBusTest.MessageBus.Queries;
using MessageBusTest.WatherForecast.Services;

namespace MessageBusTest.WatherForecast.Handlers
{
    public class GetWatherForecastDataHandler : IMessageBusHandler<GetWatherForecastDataQuery, IEnumerable<WeatherForecast>>
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public GetWatherForecastDataHandler(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        public IEnumerable<WeatherForecast> Handle(GetWatherForecastDataQuery query)
        {
            return _weatherForecastService.GetWatherForecast();
        }
    }
}
