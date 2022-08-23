using AsyncAwaitLab.Service;
using Microsoft.AspNetCore.Mvc;

namespace AsyncAwaitLab.Controllers
{
    [Route("[controller]")]
    public class JokeController : Controller
    {
        private readonly ILogger<JokeController> _logger;
        private readonly IJokeService _jokeService;

        public JokeController(ILogger<JokeController> logger,
                              IJokeService jokeService)
        {            
            _logger = logger;
            _jokeService = jokeService;
            _logger.LogInformation("Constructor");
        }

        [HttpGet("SyncJoke")]
        public IActionResult SyncJoke()
        {
            _logger.LogInformation("SyncJoke");
            return Ok(_jokeService.GetJokesSync());
        }

        [HttpGet("AsyncJoke")]
        public async Task<IActionResult> AsyncJoke()
        {
            _logger.LogInformation("AyncJoke");
            return Ok(await _jokeService.GetJokesAsync());
        }
        
    }
}