using ButterCheeseEggs.Models;
using ButterCheeseEggs.Services.Interfaces;

namespace ButterCheeseEggs.Services.Implementation
{
    public class GameService : IGameService
    {

        private GameStateAnalyzer analyzer = new GameStateAnalyzer();


        public GameState MakeNextMove(GameState state, int x, int y)
        {
            
            state.Table[x, y] = GetTileForPlayer(state.NextStepBy);

            state.Winner = analyzer.DetermineWinner(state);
            state.IsGameFinished = analyzer.IsGameFinished(state);

            SwitchPlayers(state);

            return state;
        }



        private void SwitchPlayers(GameState state)
        {
            if (!state.IsGameFinished)
            {
                switch (state.NextStepBy)
                {
                    case Players.X:
                        state.NextStepBy = Players.O;
                        break;
                    case Players.O:
                        state.NextStepBy = Players.X;
                        break;
                    default:
                        throw new InvalidOperationException("Invalid player to switch from: " + state.NextStepBy);
                }
            }
            else
            {
                state.NextStepBy = Players.None;
            }
        }



        private TileStates GetTileForPlayer(Players player)
        {
            switch (player)
            {
                case Players.X:
                    return TileStates.X;
                case Players.O:
                    return TileStates.O;
                default:
                    throw new InvalidOperationException("Cannot select Tile for Player " + player);
            }
        }
    }
}
