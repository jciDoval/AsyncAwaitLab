using AsyncAwaitLab.Models.Jokes;

namespace AsyncAwaitLab.Service
{
    public interface IJokeService
    {
        Joke GetJokesSync();
        Task<Joke> GetJokesAsync();
    }
}