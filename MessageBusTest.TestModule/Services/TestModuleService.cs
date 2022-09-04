using MessageBusTest.Data;
using MessageBusTest.MessageBus;
using MessageBusTest.MessageBus.Queries;

namespace MessageBusTest.TestModule.Services
{
    public class TestModuleService : ITestModuleService
    {
        private readonly IMessageBus _messageBus;

        public TestModuleService(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }
        public IEnumerable<WeatherForecast> GetFromWatherForecastModule()
        {
            return _messageBus.Query<IEnumerable<WeatherForecast>>(new GetWatherForecastDataQuery()
            {
                TestData = "Ela"
            });
        }
    }
}
