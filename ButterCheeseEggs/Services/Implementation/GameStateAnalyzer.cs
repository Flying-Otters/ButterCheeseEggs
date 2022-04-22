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
            bool isFirstRowWinning = state.Table[0, rowIndex].TileState == tileState;
            bool isSecondRowWinning = state.Table[1, rowIndex].TileState == tileState;
            bool isThirdRowWinning = state.Table[2, rowIndex].TileState == tileState;

            bool isWinning = isFirstRowWinning && isSecondRowWinning && isThirdRowWinning;

            if (isWinning)
            {
                state.Table[0, rowIndex].IsTileAWinner = true;
                state.Table[1, rowIndex].IsTileAWinner = true;
                state.Table[2, rowIndex].IsTileAWinner = true;
            }

            return isWinning;
        }


        private bool IsWinningColumn(GameState state, int columnIndex, TileStates tileState)
        {
            bool isWinning = (state.Table[columnIndex, 0].TileState == tileState)
                && (state.Table[columnIndex, 1].TileState == tileState)
                && (state.Table[columnIndex, 2].TileState == tileState);

            if (isWinning)
            {
                state.Table[columnIndex, 0].IsTileAWinner = true;
                state.Table[columnIndex, 1].IsTileAWinner = true;
                state.Table[columnIndex, 2].IsTileAWinner = true;
            }

            return isWinning;
        }

        private bool IsWinningFirstDiagonal(GameState state, TileStates tileState)
        {
            bool isWinning = (state.Table[0, 0].TileState == tileState) 
                && (state.Table[1, 1].TileState == tileState) 
                && (state.Table[2, 2].TileState == tileState);

            if (isWinning)
            {
                state.Table[0, 0].IsTileAWinner = true;
                state.Table[1, 1].IsTileAWinner = true;
                state.Table[2, 2].IsTileAWinner = true;
            }

            return isWinning;
        }


        private bool IsWinningSecondDiagonal(GameState state, TileStates tileState)
        {
            bool isWinning = (state.Table[2, 0].TileState == tileState) 
                && (state.Table[1, 1].TileState == tileState) 
                && (state.Table[0, 2].TileState == tileState);

            if (isWinning)
            {
                state.Table[2, 0].IsTileAWinner = true;
                state.Table[1, 1].IsTileAWinner = true;
                state.Table[0, 2].IsTileAWinner = true;
            }

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
            bool isFirstRowO = IsWinningRow(state, 0, TileStates.O);
            bool isSecondRowO = IsWinningRow(state, 1, TileStates.O);
            bool isThirdRowO = IsWinningRow(state, 2, TileStates.O);

            if (isFirstRowO || isSecondRowO || isThirdRowO)
            {
                return true;
            }

            return false;
        }


        private bool IsColumnInWinningConditionForX(GameState state)
        {

            bool isFirstColumnX = IsWinningColumn(state, 0, TileStates.X);
            bool isSecondColumnX = IsWinningColumn(state, 1, TileStates.X);
            bool isThirdColumnX = IsWinningColumn(state, 2, TileStates.X);

            if (isFirstColumnX || isSecondColumnX || isThirdColumnX)
            {
                return true;
            }

            return false;
        }


        private bool IsColumnInWinningConditionForO(GameState state)
        {

            bool isFirstColumnO = IsWinningColumn(state, 0, TileStates.O);
            bool isSecondColumnO = IsWinningColumn(state, 1, TileStates.O);
            bool isThirdColumnO = IsWinningColumn(state, 2, TileStates.O);

            if (isFirstColumnO || isSecondColumnO || isThirdColumnO)
            {
                return true;
            }

            return false;
        }


        private bool IsDiagonalInWinningConditionForX(GameState state)
        {
            bool isFirstDiagonalX = IsWinningFirstDiagonal(state, TileStates.X);
            bool isSecondDiagonalX = IsWinningSecondDiagonal(state,TileStates.X);

            if (isFirstDiagonalX || isSecondDiagonalX)
            {
                return true;
            }

            return false;
        }


        private bool IsDiagonalInWinningConditionForO(GameState state)
        {
            bool isFirstDiagonalO = IsWinningFirstDiagonal(state, TileStates.O);
            bool isSecondDiagonalO = IsWinningSecondDiagonal(state,TileStates.O);
      
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
