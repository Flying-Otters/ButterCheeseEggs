using ButterCheeseEggs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ButterCheeseEggs.Controllers
{
    public class GameController : Controller
    {
        private const string GameStateSessionId = "GameState";

        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }


        public IActionResult Play()
        {
            GameState state = GetGameState();

            return View(state);
        }


        public IActionResult Reset()
        {
            GameState state = new GameState();

            SaveGameState(state);

            return View(nameof(Play));
        }



        public IActionResult MakeMove(int x, int y)
        {
            GameState state = GetGameState();


            // Run game logic:
            //  - Process the newly made move into the game state
            //  - Check if there's a winner and process that information in the gamestate object

            SaveGameState(state);


            return View(nameof(Play));
        }


        public GameState GetGameState()
        {
            GameState state;
            string? stateJson = HttpContext.Session?.GetString(GameStateSessionId);

            if (stateJson == null)
            {
                state = new GameState();
                HttpContext.Session?.SetString(GameStateSessionId, state.ToJson());
            }
            else
            {
                state = GameState.FromJson(stateJson);
            }

            return state;
        }


        public void SaveGameState(GameState state)
        {
            if (state == null) { throw new ArgumentNullException("state"); }

            string json = state.ToJson();

            HttpContext.Session?.SetString(GameStateSessionId, json);
        }

    }
}
