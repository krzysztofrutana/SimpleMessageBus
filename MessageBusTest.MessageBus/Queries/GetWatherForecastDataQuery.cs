using MessageBusTest.Data;
using MessageBusTest.MessageBus.Abstraction;

namespace MessageBusTest.MessageBus.Queries
{
    public class GetWatherForecastDataQuery : IQuery<IEnumerable<WeatherForecast>>
    {
        public string? TestData { get; set; }
    }
}
