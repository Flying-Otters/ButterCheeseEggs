using ButterCheeseEggs.Models;

namespace ButterCheeseEggs.Services.Implementation
{
    public class GameStateAnalyzer
    {

        public Players DetermineWinner(GameState state)
        {
            Players winner = Players.None;

            if (HasEmptyTiles(state))
            {
                winner = Players.None;
            }

            if (IsRowInWinningConditionForX(state) || IsColumnInWinningConditionForX(state))
            {
                winner = Players.X;
            }
            if (IsRowInWinningConditionForO(state) || IsColumnInWinningConditionForO(state))
            {
                winner = Players.O;
            }
            if (IsGameATie(state))
            {
                winner = Players.None;
            }

            return winner;
        }


        private bool IsRowInWinningConditionForX(GameState state)
        {
            bool isFirstRowX = (state.Table[0, 0] == TileStates.X) && (state.Table[1,0] == TileStates.X) && (state.Table[2,0] == TileStates.X);
            bool isSecondRowX = (state.Table[0,1] == TileStates.X) && (state.Table[1,1] == TileStates.X) && (state.Table[2,1] == TileStates.X);
            bool isThirdRowX = (state.Table[0,2] == TileStates.X) && (state.Table[1,2] == TileStates.X) && (state.Table[2,2] == TileStates.X);

            if (isFirstRowX || isSecondRowX || isThirdRowX)
            {
                return true;
            }

            return false;
        }


        private bool IsRowInWinningConditionForO(GameState state)
        {
            bool isFirstRowO = (state.Table[0, 0] == TileStates.O) && (state.Table[1, 0] == TileStates.O) && (state.Table[2, 0] == TileStates.O);
            bool isSecondRowO = (state.Table[0, 1] == TileStates.O) && (state.Table[1, 1] == TileStates.O) && (state.Table[2, 1] == TileStates.O);
            bool isThirdRowO = (state.Table[0, 2] == TileStates.O) && (state.Table[1, 2] == TileStates.O) && (state.Table[2, 2] == TileStates.O);

            if (isFirstRowO || isSecondRowO || isThirdRowO)
            {
                return true;
            }

            return false;
        }


        private bool IsColumnInWinningConditionForX(GameState state)
        {

            bool isFirstColumnX = (state.Table[0, 0] == TileStates.X) && (state.Table[0,1] == TileStates.X) && (state.Table[0,2] == TileStates.X);
            bool isSecondColumnX = (state.Table[1,0] == TileStates.X) && (state.Table[1, 1] == TileStates.X) && (state.Table[1,2] == TileStates.X);
            bool isThirdColumnX = (state.Table[2,0] == TileStates.X) && (state.Table[2,1] == TileStates.X) && (state.Table[2, 2] == TileStates.X);

            if (isFirstColumnX || isSecondColumnX || isThirdColumnX)
            {
                return true;
            }

            return false;
        }


        private bool IsColumnInWinningConditionForO(GameState state)
        {

            bool isFirstColumnO = (state.Table[0, 0] == TileStates.O) && (state.Table[0, 1] == TileStates.O) && (state.Table[0, 2] == TileStates.O);
            bool isSecondColumnO = (state.Table[1, 0] == TileStates.O) && (state.Table[1, 1] == TileStates.O) && (state.Table[1, 2] == TileStates.O);
            bool isThirdColumnO = (state.Table[2, 0] == TileStates.O) && (state.Table[2, 1] == TileStates.O) && (state.Table[2, 2] == TileStates.O);

            if (isFirstColumnO || isSecondColumnO || isThirdColumnO)
            {
                return true;
            }

            return false;
        }


        private bool IsGameATie(GameState state)
        {
            if (state.Winner == Players.None && !HasEmptyTiles(state))
            {
                return true;
            }

            return false;
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
