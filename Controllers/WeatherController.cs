using AsyncAwaitLab.Service;
using Microsoft.AspNetCore.Mvc;

namespace AsyncAwaitLab.Controllers
{
    [Route("[controller]")]
    public class WeatherController : Controller
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly IWeatherService _weatherService;

        public WeatherController(ILogger<WeatherController> logger,
                              IWeatherService weatherService)
        {            
            _logger = logger;
            _weatherService = weatherService;
            _logger.LogInformation("Constructor");
        }

        [HttpGet("SyncWeather")]
        public IActionResult SyncWeather()
        {
            _logger.LogInformation("SyncJoke");
            return Ok(_weatherService.GetWeatherSync());
        }

        [HttpGet("AsyncWeather")]
        public async Task<IActionResult> AsyncWeather()
        {
            _logger.LogInformation("AsyncWeather");
            return Ok(await _weatherService.GetWeatherAsync());
        }
        
    }
}