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
    public class GameStateAnalyzer_DetermineWinner
    {
        [TestMethod]
        public void WinnerIsNoneIfGameStateHasEmptyTiles()
        {
            GameStateAnalyzer analyzer = new GameStateAnalyzer();
            GameState state = new GameState();

            Players result = analyzer.DetermineWinner(state);

            Assert.AreEqual(Players.None, result);
        }


        [TestMethod]
        public void WinnerIsXIfRowIsInWinningConditionForX()
        {
            GameStateAnalyzer analyzer = new GameStateAnalyzer();
            GameState state = new GameState();

            state.Table[0,0] = TileStates.X;
            state.Table[1,0] = TileStates.X;
            state.Table[2,0] = TileStates.X;
            state.Table[2, 1] = TileStates.O;
            state.Table[2, 2] = TileStates.O;
            state.Table[0, 1] = TileStates.O;
            state.Table[1, 2] = TileStates.O;

            Players result = analyzer.DetermineWinner(state);

            Assert.AreEqual(Players.X,result);
        }


        [TestMethod]
        public void WinnerIsOIfRowIsInWinningConditionForO()
        {
            GameStateAnalyzer analyzer = new GameStateAnalyzer();
            GameState state = new GameState();

            state.Table[0, 0] = TileStates.O;
            state.Table[1, 0] = TileStates.O;
            state.Table[2, 0] = TileStates.O;
            state.Table[2, 1] = TileStates.X;
            state.Table[2, 2] = TileStates.X;
            state.Table[0, 1] = TileStates.O;
            state.Table[1, 2] = TileStates.X;

            Players result = analyzer.DetermineWinner(state);

            Assert.AreEqual(Players.O, result);
        }


        [TestMethod]
        public void WinnerIsXIfColumnIsInWinningConditionForX()
        {
            GameStateAnalyzer analyzer = new GameStateAnalyzer();
            GameState state = new GameState();

            state.Table[0, 0] = TileStates.O;
            state.Table[1, 0] = TileStates.O;
            state.Table[2, 0] = TileStates.X;
            state.Table[2, 1] = TileStates.X;
            state.Table[2, 2] = TileStates.X;
            state.Table[0, 1] = TileStates.O;
            state.Table[1, 2] = TileStates.X;

            Players result = analyzer.DetermineWinner(state);

            Assert.AreEqual(Players.X, result);
        }


        [TestMethod]
        public void WinnerIsOIfColumnIsInWinningConditionForO()
        {
            GameStateAnalyzer analyzer = new GameStateAnalyzer();
            GameState state = new GameState();

            state.Table[0, 0] = TileStates.O;
            state.Table[2, 0] = TileStates.X;
            state.Table[2, 1] = TileStates.X;
            state.Table[2, 2] = TileStates.X;
            state.Table[0, 1] = TileStates.O;
            state.Table[1, 2] = TileStates.O;
            state.Table[1, 0] = TileStates.O;
            state.Table[1, 1] = TileStates.O;

            Players result = analyzer.DetermineWinner(state);

            Assert.AreEqual(Players.O, result);
        }



        [TestMethod]
        public void WinnerIsNotXIfOnlyTwoRowsInColumnAreX()
        {
            GameStateAnalyzer analyzer = new GameStateAnalyzer();
            GameState state = new GameState();

            state.Table[0, 1] = TileStates.X;
            state.Table[1, 1] = TileStates.O;
            state.Table[2, 1] = TileStates.O;
            state.Table[0, 2] = TileStates.X;
            state.Table[1, 2] = TileStates.O;
            state.Table[2, 2] = TileStates.X;
            state.Table[0, 0] = TileStates.O;
            state.Table[1, 0] = TileStates.X;
            state.Table[2, 0] = TileStates.X;

            Players result = analyzer.DetermineWinner(state);

            Assert.IsFalse(result == Players.X);
        }


        [TestMethod]
        public void WinnerIsNotXIfOnlyTwoColumnsInRowAreX()
        {
            GameStateAnalyzer analyzer = new GameStateAnalyzer();
            GameState state = new GameState();

            state.Table[0, 0] = TileStates.O;
            state.Table[2, 0] = TileStates.X;
            state.Table[2, 1] = TileStates.O;
            state.Table[2, 2] = TileStates.X;
            state.Table[0, 1] = TileStates.X;
            state.Table[1, 2] = TileStates.O;
            state.Table[1, 0] = TileStates.X;
            state.Table[1, 1] = TileStates.X;

            Players result = analyzer.DetermineWinner(state);

            Assert.IsFalse(result == Players.X);
        }

        [TestMethod]
        public void WinnerIsNotOIfOnlyTwoRowsInColumnAreO()
        {
            GameStateAnalyzer analyzer = new GameStateAnalyzer();
            GameState state = new GameState();

            state.Table[0, 0] = TileStates.O;
            state.Table[1, 0] = TileStates.X;
            state.Table[2, 0] = TileStates.X;
            state.Table[0, 1] = TileStates.X;
            state.Table[1, 1] = TileStates.O;
            state.Table[2, 1] = TileStates.O;
            state.Table[0, 2] = TileStates.X;
            state.Table[1, 2] = TileStates.O;
            state.Table[2, 2] = TileStates.X;


            Players result = analyzer.DetermineWinner(state);

            Assert.IsFalse(result == Players.O);
        }


        [TestMethod]
        public void WinnerIsNotOIfOnlyTwoColumnsInRowAreO()
        {
            GameStateAnalyzer analyzer = new GameStateAnalyzer();
            GameState state = new GameState();

            state.Table[0, 0] = TileStates.O;
            state.Table[1, 0] = TileStates.X;
            state.Table[2, 0] = TileStates.X;
            state.Table[0, 1] = TileStates.X;
            state.Table[1, 1] = TileStates.O;
            state.Table[2, 1] = TileStates.O;
            state.Table[0, 2] = TileStates.X;
            state.Table[1, 2] = TileStates.O;
            state.Table[2, 2] = TileStates.X;

            Players result = analyzer.DetermineWinner(state);

            Assert.IsFalse(result == Players.O);
        }


        [TestMethod]
        public void PlayerIsNoneIfGameIsATie()
        {
            GameStateAnalyzer analyzer = new GameStateAnalyzer();
            GameState state = new GameState();

            state.Table[0, 0] = TileStates.O;
            state.Table[0, 1] = TileStates.X;
            state.Table[0, 2] = TileStates.X;
            state.Table[1, 0] = TileStates.X;
            state.Table[1, 1] = TileStates.O;
            state.Table[1, 2] = TileStates.O;
            state.Table[2, 0] = TileStates.X;
            state.Table[2, 1] = TileStates.O;
            state.Table[2, 2] = TileStates.X;

            Players result = analyzer.DetermineWinner(state);

            Assert.IsTrue(result == Players.None);
        }


        [TestMethod]
        public void WinnerIsOIfFirstDiagonalIsInAWinningPositionForO()
        {
            GameStateAnalyzer analyzer = new GameStateAnalyzer();
            GameState state = new GameState();

            state.Table[0, 0] = TileStates.O;
            state.Table[1, 0] = TileStates.X;
            state.Table[2, 0] = TileStates.X;
            state.Table[0, 1] = TileStates.X;
            state.Table[1, 1] = TileStates.O;
            state.Table[2, 1] = TileStates.O;
            state.Table[0, 2] = TileStates.X;
            state.Table[1, 2] = TileStates.O;
            state.Table[2, 2] = TileStates.O;

            Players result = analyzer.DetermineWinner(state);

            Assert.AreEqual(Players.O, result);
        }


        [TestMethod]
        public void WinnerIsOIfSecondDiagonalIsInAWinningPositionForO()
        {
            GameStateAnalyzer analyzer = new GameStateAnalyzer();
            GameState state = new GameState();

            state.Table[0, 0] = TileStates.X;
            state.Table[1, 0] = TileStates.X;
            state.Table[2, 0] = TileStates.O;
            state.Table[0, 1] = TileStates.X;
            state.Table[1, 1] = TileStates.O;
            state.Table[2, 1] = TileStates.X;
            state.Table[0, 2] = TileStates.O;
            state.Table[1, 2] = TileStates.O;
            state.Table[2, 2] = TileStates.O;

            Players result = analyzer.DetermineWinner(state);

            Assert.AreEqual(Players.O, result);
        }


        [TestMethod]
        public void WinnerIsXIfFirstDiagonalIsInAWinningPositionForX()
        {
            GameStateAnalyzer analyzer = new GameStateAnalyzer();
            GameState state = new GameState();

            state.Table[0, 0] = TileStates.X;
            state.Table[1, 0] = TileStates.X;
            state.Table[2, 0] = TileStates.O;
            state.Table[0, 1] = TileStates.X;
            state.Table[1, 1] = TileStates.X;
            state.Table[2, 1] = TileStates.O;
            state.Table[0, 2] = TileStates.O;
            state.Table[1, 2] = TileStates.O;
            state.Table[2, 2] = TileStates.X;

            Players result = analyzer.DetermineWinner(state);

            Assert.AreEqual(Players.X, result);
        }



        [TestMethod]
        public void WinnerIsXIfSecondDiagonalIsInAWinningPositionForX()
        {
            GameStateAnalyzer analyzer = new GameStateAnalyzer();
            GameState state = new GameState();

            state.Table[0, 0] = TileStates.O;
            state.Table[1, 0] = TileStates.X;
            state.Table[2, 0] = TileStates.X;
            state.Table[0, 1] = TileStates.X;
            state.Table[1, 1] = TileStates.X;
            state.Table[2, 1] = TileStates.O;
            state.Table[0, 2] = TileStates.X;
            state.Table[1, 2] = TileStates.O;
            state.Table[2, 2] = TileStates.X;

            Players result = analyzer.DetermineWinner(state);

            Assert.AreEqual(Players.X, result);
        }


        [TestMethod]
        public void WinnerIsNotXIfOnlyTwoTilesInFirstDiagonalAreX()
        {
            GameStateAnalyzer analyzer = new GameStateAnalyzer();
            GameState state = new GameState();

            state.Table[0, 0] = TileStates.X;
            state.Table[1, 0] = TileStates.X;
            state.Table[2, 0] = TileStates.O;
            state.Table[0, 1] = TileStates.O;
            state.Table[1, 1] = TileStates.X;
            state.Table[2, 1] = TileStates.X;
            state.Table[0, 2] = TileStates.X;
            state.Table[1, 2] = TileStates.O;
            state.Table[2, 2] = TileStates.O;

            Players result = analyzer.DetermineWinner(state);

            Assert.IsTrue(result == Players.None);
        }


        [TestMethod]
        public void WinnerIsNotXIfOnlyTwoTilesInSecondDiagonalAreX()
        {
            GameStateAnalyzer analyzer = new GameStateAnalyzer();
            GameState state = new GameState();

            state.Table[0, 0] = TileStates.X;
            state.Table[1, 0] = TileStates.X;
            state.Table[2, 0] = TileStates.O;
            state.Table[0, 1] = TileStates.O;
            state.Table[1, 1] = TileStates.X;
            state.Table[2, 1] = TileStates.X;
            state.Table[0, 2] = TileStates.X;
            state.Table[1, 2] = TileStates.O;
            state.Table[2, 2] = TileStates.O;

            Players result = analyzer.DetermineWinner(state);

            Assert.IsTrue(result == Players.None);
        }


        [TestMethod]
        public void WinnerIsNotOIfOnlyTwoTilesInFirstDiagonalAreO()
        {
            GameStateAnalyzer analyzer = new GameStateAnalyzer();
            GameState state = new GameState();

            state.Table[0, 0] = TileStates.O;
            state.Table[1, 0] = TileStates.X;
            state.Table[2, 0] = TileStates.O;
            state.Table[0, 1] = TileStates.X;
            state.Table[1, 1] = TileStates.O;
            state.Table[2, 1] = TileStates.O;
            state.Table[0, 2] = TileStates.X;
            state.Table[1, 2] = TileStates.O;
            state.Table[2, 2] = TileStates.X;

            Players result = analyzer.DetermineWinner(state);

            Assert.IsTrue(result == Players.None);
        }


        [TestMethod]
        public void WinnerIsNotOIfOnlyTwoTilesInSecondDiagonalAreO()
        {
            GameStateAnalyzer analyzer = new GameStateAnalyzer();
            GameState state = new GameState();

            state.Table[0, 0] = TileStates.O;
            state.Table[1, 0] = TileStates.X;
            state.Table[2, 0] = TileStates.O;
            state.Table[0, 1] = TileStates.X;
            state.Table[1, 1] = TileStates.O;
            state.Table[2, 1] = TileStates.O;
            state.Table[0, 2] = TileStates.X;
            state.Table[1, 2] = TileStates.O;
            state.Table[2, 2] = TileStates.X;

            Players result = analyzer.DetermineWinner(state);

            Assert.IsTrue(result == Players.None);
        }
    }
}
