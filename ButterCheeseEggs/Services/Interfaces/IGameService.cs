using ButterCheeseEggs.Models;

namespace ButterCheeseEggs.Services.Interfaces
{
    public interface IGameService
    {

        GameState MakeNextMove(GameState state, int x, int y);

    }
}
