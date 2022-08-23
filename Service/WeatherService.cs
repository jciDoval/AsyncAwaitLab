using AsyncAwaitLab.Models.Weathers;
using AsyncAwaitLab.Service.Client;

namespace AsyncAwaitLab.Service
{
    public class WeatherService : IWeatherService
    {
        private readonly ILogger<WeatherService> _logger;
        private readonly WeatherHttpClient _client;

        public WeatherService(ILogger<WeatherService> logger,
                           WeatherHttpClient client)
        {
            _logger = logger;
            _client = client;
        }

        public Weather GetWeatherSync()
        {
            _logger.LogInformation("Sync Test Weather");
            return _client.ObtainWeatherSync();
        }

        public async Task<Weather> GetWeatherAsync()
        {
            _logger.LogInformation("Async Test Weather");
            return await _client.ObtainWeatherAsync();
        }
    }
}