using System.Text.Json;
using AsyncAwaitLab.Models.Jokes;
using AsyncAwaitLab.Options;
using Microsoft.Extensions.Options;

namespace AsyncAwaitLab.Service.Client
{
    public class JokeHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly IOptionsMonitor<JokeHttpOptions> _options;

        private readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

        public JokeHttpClient(HttpClient httpClient,
                              IOptionsMonitor<JokeHttpOptions> options)
        {
            _httpClient = httpClient;
            _options = options;
        }

        public async Task<Joke> ObtainJokeAsync()
        {
            var response = await _httpClient.GetAsync(_options.CurrentValue.BaseAddress);

            response.EnsureSuccessStatusCode();

            var joke = JsonSerializer.Deserialize<Joke>(await response.Content.ReadAsStreamAsync(), jsonOptions);

            return joke;
        }

        public Joke ObtainJokeSync()
        {
            var response = _httpClient.GetAsync(_options.CurrentValue.BaseAddress).Result;

            response.EnsureSuccessStatusCode();

            var joke = JsonSerializer.Deserialize<Joke>(response.Content.ReadAsStream(), jsonOptions);
            return joke;
        }

    }
}