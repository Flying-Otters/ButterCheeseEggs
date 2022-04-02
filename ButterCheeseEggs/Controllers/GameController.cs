using Microsoft.AspNetCore.Mvc;

namespace ButterCheeseEggs.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }

        public IActionResult Play()
        {
            return View();
        }
    }
}
