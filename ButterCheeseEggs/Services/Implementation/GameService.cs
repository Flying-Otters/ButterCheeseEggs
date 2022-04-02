using ButterCheeseEggs.Models;
using ButterCheeseEggs.Services.Interfaces;

namespace ButterCheeseEggs.Services.Implementation
{
    public class GameService : IGameService
    {
        public GameState MakeNextMove(GameState state, int x, int y)
        {
            return state;
        }
    }
}
