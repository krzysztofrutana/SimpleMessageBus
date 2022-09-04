using MessageBusTest.Data;
using MessageBusTest.TestModule.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MessageBusTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestModuleController : ControllerBase
    {

        private readonly ILogger<TestModuleController> _logger;
        private readonly ITestModuleService _testModuleService;

        public TestModuleController(ILogger<TestModuleController> logger, ITestModuleService testModuleService)
        {
            _logger = logger;
            _testModuleService = testModuleService;
        }

        [HttpGet(Name = "GetWeatherForecastFromOtherService")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _testModuleService.GetFromWatherForecastModule();
        }
    }
}