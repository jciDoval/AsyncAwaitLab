using System.Text.Json;
using AsyncAwaitLab.Models.Weathers;
using AsyncAwaitLab.Options;
using Microsoft.Extensions.Options;

namespace AsyncAwaitLab.Service.Client
{
    public class WeatherHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly IOptionsMonitor<WeatherHttpOptions> _options;

        private readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

        public WeatherHttpClient(HttpClient httpClient,
                              IOptionsMonitor<WeatherHttpOptions> options)
        {
            _httpClient = httpClient;
            _options = options;
        }

        public async Task<Weather> ObtainWeatherAsync()
        {
            var response = await _httpClient.GetAsync(_options.CurrentValue.BaseAddress);

            response.EnsureSuccessStatusCode();

            var weather = JsonSerializer.Deserialize<Weather>(await response.Content.ReadAsStreamAsync(), jsonOptions);

            return weather;
        }

        public Weather ObtainWeatherSync()
        {
            var response = _httpClient.GetAsync(_options.CurrentValue.BaseAddress).Result;

            response.EnsureSuccessStatusCode();

            var weather = JsonSerializer.Deserialize<Weather>(response.Content.ReadAsStream(), jsonOptions);
            return weather;
        }

    }
}