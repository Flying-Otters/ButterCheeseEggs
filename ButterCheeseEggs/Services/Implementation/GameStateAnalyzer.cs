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
            if (state.Winner != Players.None)
            {
                return true;
            }

            return !HasEmptyTiles(state);
        }


        private bool HasEmptyTiles(GameState state)
        {
            int count = 0;

            foreach (TileStates tile in state.Table.LinearData)
            {
                if (tile == TileStates.Empty)
                {
                    count++;
                }
            }

            bool hasEmptyTiles = (count != 0);

            return hasEmptyTiles;
        }
    }
}
