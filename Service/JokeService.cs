using AsyncAwaitLab.Models.Jokes;
using AsyncAwaitLab.Service.Client;

namespace AsyncAwaitLab.Service
{
    public class JokeService : IJokeService
    {

        private readonly ILogger<JokeService> _logger;
        private readonly JokeHttpClient _client;

        public JokeService(ILogger<JokeService> logger,
                           JokeHttpClient client)
        {
            _logger = logger;
            _client = client;
        }

        public Joke GetJokesSync()
        {
            _logger.LogInformation("Sync Test Jokes");
            return _client.ObtainJokeSync();
        }

        public async Task<Joke> GetJokesAsync()
        {
            _logger.LogInformation("Async Test Jokes");
            return await _client.ObtainJokeAsync();
        }
    }
}