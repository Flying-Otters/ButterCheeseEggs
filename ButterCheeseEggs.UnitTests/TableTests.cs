using ButterCheeseEggs.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButterCheeseEggs.UnitTests
{
    [TestClass]
    public class TableTests
    {


        [TestMethod]
        public void ValidReadFromNewTableReturnsDefault()
        {
            Table<TileStates> table = new Table<TileStates>(3,3);

            TileStates result = table[1, 2];

            Assert.AreEqual(TileStates.Empty, result);
        }


        [TestMethod]
        public void ReadOutsideXSizeThrowsException()
        {
            Table<TileStates> table = new Table<TileStates>(3, 3);

            Assert.ThrowsException<IndexOutOfRangeException>(() =>
           {
               TileStates result = table[5, 2];
           });
        }


        [TestMethod]
        public void ReadOutsideYSizeThrowsException()
        {
            Table<TileStates> table = new Table<TileStates>(3, 3);

            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                TileStates result = table[1, 7];
            });
        }


        [TestMethod]
        public void SetValueRetainsCorrectly()
        {
            Table<TileStates> table = new Table<TileStates>(3, 3);

            table[1, 1] = TileStates.X;

            Assert.AreEqual(TileStates.Empty, table[0, 0]);
            Assert.AreEqual(TileStates.Empty, table[0, 1]);
            Assert.AreEqual(TileStates.Empty, table[0, 2]);
            Assert.AreEqual(TileStates.Empty, table[1, 0]);

            Assert.AreEqual(TileStates.X, table[1, 1]);

            Assert.AreEqual(TileStates.Empty, table[1, 2]);
            Assert.AreEqual(TileStates.Empty, table[2, 0]);
            Assert.AreEqual(TileStates.Empty, table[2, 1]);
            Assert.AreEqual(TileStates.Empty, table[2, 2]);
        }



    }
}
