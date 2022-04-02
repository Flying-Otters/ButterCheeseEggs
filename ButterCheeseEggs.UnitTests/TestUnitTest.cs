using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ButterCheeseEggs.UnitTests
{
    [TestClass]
    public class TestUnitTest
    {
        [TestMethod]
        public void ValidateUnitTest()
        {
            UnitTestTester tester = new UnitTestTester();

            int result = tester.Add(5, 3);

            Assert.AreEqual(8, result);
        }
    }
}