using MessageBusTest.Data;

namespace MessageBusTest.TestModule.Services
{
    public interface ITestModuleService
    {
        IEnumerable<WeatherForecast> GetFromWatherForecastModule();
    }
}
