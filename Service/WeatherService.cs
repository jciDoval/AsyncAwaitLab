using AsyncAwaitLab.Models.Weathers;
using AsyncAwaitLab.Service.Client;

namespace AsyncAwaitLab.Service
{
    public class WeatherService : IWeatherService
    {
        private readonly ILogger<JokeService> _logger;
        private readonly WeatherHttpClient _client;

        public WeatherService(ILogger<JokeService> logger,
                           WeatherHttpClient client)
        {
            _logger = logger;
            _client = client;
        }

        public Weather GetWeatherSync()
        {
            _logger.LogInformation("Sync Test Jokes");
            return _client.ObtainWeatherSync();
        }

        public async Task<Weather> GetWeatherAsync()
        {
            _logger.LogInformation("Async Test Jokes");
            return await _client.ObtainWeatherAsync();
        }
    }
}