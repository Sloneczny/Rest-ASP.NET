using Microsoft.AspNetCore.Mvc;

namespace webAPIrest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        
        private readonly WatherForcastService _weatherForecastService;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
           _weatherForecastService= new WatherForcastService();
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var result = _weatherForecastService.Get();
            return result;
        }
    }
}