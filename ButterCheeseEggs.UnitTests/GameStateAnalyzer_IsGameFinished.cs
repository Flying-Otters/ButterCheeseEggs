using ButterCheeseEggs.Models;
using ButterCheeseEggs.Services.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButterCheeseEggs.UnitTests
{
    [TestClass]
    public class GameStateAnalyzer_IsGameFinished
    {

        [TestMethod]
        public void WinnerXMakeGameFinished()
        {
            GameStateAnalyzer analyzer = new GameStateAnalyzer();
            GameState state = new GameState()
            {
                Winner = Players.X
            };

            bool result = analyzer.IsGameFinished(state);

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void WinnerOMakeGameFinished()
        {
            GameStateAnalyzer analyzer = new GameStateAnalyzer();
            GameState state = new GameState()
            {
                Winner = Players.O
            };

            bool result = analyzer.IsGameFinished(state);

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void NoWinnerWithEmptyTilesMakeGameNotFinished()
        {
            GameStateAnalyzer analyzer = new GameStateAnalyzer();
            GameState state = new GameState()
            {
                Winner = Players.None
            };

            bool result = analyzer.IsGameFinished(state);

            Assert.IsFalse(result);
        }


        [TestMethod]
        public void NoWinnerWithNoEmptyTilesMakeGameFinishedDraw()
        {
            GameStateAnalyzer analyzer = new GameStateAnalyzer();
            GameState state = new GameState()
            {
                Winner = Players.None
            };

            TileStates tile = TileStates.X;
            for (int i = 0; i < state.Table.LinearData.Count; i++)
            {
                state.Table.LinearData[i] = tile;
                tile = tile == TileStates.O ? TileStates.X : TileStates.O;
            }

            bool result = analyzer.IsGameFinished(state);

            Assert.IsTrue(result);
        }

    }
}
