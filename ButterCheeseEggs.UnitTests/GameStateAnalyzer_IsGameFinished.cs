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

            analyzer.IsGameFinished(state);

            Assert.IsTrue(state.IsGameFinished);
        }


        [TestMethod]
        public void WinnerOMakeGameFinished()
        {
            GameStateAnalyzer analyzer = new GameStateAnalyzer();
            GameState state = new GameState()
            {
                Winner = Players.O
            };

            analyzer.IsGameFinished(state);

            Assert.IsTrue(state.IsGameFinished);
        }

        [TestMethod]
        public void NoWinnerWithEmptyTilesMakeGameNotFinished()
        {
            GameStateAnalyzer analyzer = new GameStateAnalyzer();
            GameState state = new GameState()
            {
                Winner = Players.None
            };

            analyzer.IsGameFinished(state);

            Assert.IsFalse(state.IsGameFinished);
        }


    }
}
