using AsyncAwaitLab.Models.Weathers;

namespace AsyncAwaitLab.Service
{
    public interface IWeatherService
    {
        Weather GetWeatherSync();
        Task<Weather> GetWeatherAsync();
    }
}