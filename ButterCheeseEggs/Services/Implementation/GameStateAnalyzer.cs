using ButterCheeseEggs.Models;

namespace ButterCheeseEggs.Services.Implementation
{
    public class GameStateAnalyzer
    {
        public Players DetermineWinner(GameState state)
        {
            Players winner = Players.None;
            bool XIsInWinningCondition = IsRowInWinningConditionForX(state) || IsColumnInWinningConditionForX(state) || IsDiagonalInWinningConditionForX(state);
            bool OIsInWinningCondition = IsRowInWinningConditionForO(state) || IsColumnInWinningConditionForO(state) || IsDiagonalInWinningConditionForO(state);

            if (HasEmptyTiles(state) || IsGameATie(state))
            {
                winner = Players.None;
            }

            if (XIsInWinningCondition)
            {
                winner = Players.X;
            }
            if (OIsInWinningCondition)
            {
                winner = Players.O;
            }
            
            return winner;
        }


        private bool IsWinningRow(GameState state, int rowIndex, TileStates tileState)
        {
            bool isWinning = (state.Table[0, rowIndex].TileState == tileState) 
                && (state.Table[1, rowIndex].TileState == tileState) 
                && (state.Table[2, rowIndex].TileState == tileState);
            return isWinning;
        }


        private bool IsRowInWinningConditionForX(GameState state)
        {
            bool isFirstRowX = IsWinningRow(state, 0, TileStates.X);
            bool isSecondRowX = IsWinningRow(state, 1, TileStates.X);
            bool isThirdRowX = IsWinningRow(state, 2, TileStates.X);

            if (isFirstRowX || isSecondRowX || isThirdRowX)
            {
                return true;
            }

            return false;
        }


        private bool IsRowInWinningConditionForO(GameState state)
        {
            bool isFirstRowO = (state.Table[0, 0].TileState == TileStates.O) && (state.Table[1, 0].TileState == TileStates.O) && (state.Table[2, 0].TileState == TileStates.O);
            bool isSecondRowO = (state.Table[0, 1].TileState == TileStates.O) && (state.Table[1, 1].TileState == TileStates.O) && (state.Table[2, 1].TileState == TileStates.O);
            bool isThirdRowO = (state.Table[0, 2].TileState == TileStates.O) && (state.Table[1, 2].TileState == TileStates.O) && (state.Table[2, 2].TileState == TileStates.O);

            if (isFirstRowO || isSecondRowO || isThirdRowO)
            {
                return true;
            }

            return false;
        }


        private bool IsColumnInWinningConditionForX(GameState state)
        {

            bool isFirstColumnX = (state.Table[0, 0].TileState == TileStates.X) && (state.Table[0,1].TileState == TileStates.X) && (state.Table[0,2].TileState == TileStates.X);
            bool isSecondColumnX = (state.Table[1,0].TileState == TileStates.X) && (state.Table[1, 1].TileState == TileStates.X) && (state.Table[1,2].TileState == TileStates.X);
            bool isThirdColumnX = (state.Table[2,0].TileState == TileStates.X) && (state.Table[2,1].TileState == TileStates.X) && (state.Table[2, 2].TileState == TileStates.X);

            if (isFirstColumnX || isSecondColumnX || isThirdColumnX)
            {
                return true;
            }

            return false;
        }


        private bool IsColumnInWinningConditionForO(GameState state)
        {

            bool isFirstColumnO = (state.Table[0, 0].TileState == TileStates.O) && (state.Table[0, 1].TileState == TileStates.O) && (state.Table[0, 2].TileState == TileStates.O);
            bool isSecondColumnO = (state.Table[1, 0].TileState == TileStates.O) && (state.Table[1, 1].TileState == TileStates.O) && (state.Table[1, 2].TileState == TileStates.O);
            bool isThirdColumnO = (state.Table[2, 0].TileState == TileStates.O) && (state.Table[2, 1].TileState == TileStates.O) && (state.Table[2, 2].TileState == TileStates.O);

            if (isFirstColumnO || isSecondColumnO || isThirdColumnO)
            {
                return true;
            }

            return false;
        }


        private bool IsDiagonalInWinningConditionForX(GameState state)
        {
            bool isFirstDiagonalX = (state.Table[0, 0].TileState == TileStates.X) && (state.Table[1, 1].TileState == TileStates.X) && (state.Table[2, 2].TileState == TileStates.X);
            bool isSecondDiagonalX = (state.Table[2, 0].TileState == TileStates.X) && (state.Table[1, 1].TileState == TileStates.X) && (state.Table[0, 2].TileState == TileStates.X);

            if (isFirstDiagonalX || isSecondDiagonalX)
            {
                return true;
            }

            return false;
        }


        private bool IsDiagonalInWinningConditionForO(GameState state)
        {
            bool isFirstDiagonalO = (state.Table[0, 0].TileState == TileStates.O) && (state.Table[1, 1].TileState == TileStates.O) && (state.Table[2, 2].TileState == TileStates.O);
            bool isSecondDiagonalO = (state.Table[2, 0].TileState == TileStates.O) && (state.Table[1, 1].TileState == TileStates.O) && (state.Table[0, 2].TileState == TileStates.O);
      
            if (isFirstDiagonalO || isSecondDiagonalO)
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

            foreach (Tile tile in state.Table.LinearData)
            {
                if (tile.TileState == TileStates.Empty)
                {
                    count++;
                }
            }

            bool hasEmptyTiles = (count != 0);

            return hasEmptyTiles;
        }
    }
}
