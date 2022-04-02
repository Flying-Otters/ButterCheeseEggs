using ButterCheeseEggs.Models;

namespace ButterCheeseEggs.Services.Implementation
{
    public class GameStateAnalyzer
    {

        public Players DetermineWinner(GameState state)
        {




            return Players.None;
        }


        public bool IsGameFinished(GameState state)
        {

            // -> If there's a winner in the state, then the game is finished.
            // -> Otherwise, if there's no empty tiles, then the game is finished
            // Otherwise, the game is not finished
            
            return false;
        }
    }
}
