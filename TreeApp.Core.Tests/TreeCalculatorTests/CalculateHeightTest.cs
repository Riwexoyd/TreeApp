using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace TreeApp.Core.Tests.TreeCalculatorTests
{
    [TestClass]
    public class CalculateHeightTest
    {
        public Random Random { get; private set; }

        [TestInitialize]
        public void Setup()
        {
            Random = new Random();
        }

        [TestMethod]
        public void HeightShouldBeEqualForSameSeed()
        {
            var days = 30;
            var seed = 150;

            var height = TreeCalculator.CalculateHeight(days, seed);
            var height2 = TreeCalculator.CalculateHeight(days, seed);

            Assert.AreEqual(height, height2);
        }

        [TestMethod]
        public void AfterYearShouldBeBetween_3_And_4()
        {
            var days = 365;
            var seed = Random.Next();

            var height = TreeCalculator.CalculateHeight(days, seed);

            Assert.That.Between(height, 3, 4, seed);
        }

        [TestMethod]
        public void AfterHalfOfYearShouldBeBetween_1dot5_And_2()
        {
            var days = 365 / 2 + 1;
            var seed = Random.Next();

            var height = TreeCalculator.CalculateHeight(days, seed);

            Assert.That.Between(height, 1.5, 2.1, seed);
        }

        [TestMethod]
        public void AfterTwoYearShouldBeBetween_13_And_24()
        {
            var days = 365 * 2;
            var seed = Random.Next();

            var height = TreeCalculator.CalculateHeight(days, seed);

            Assert.That.Between(height, 13, 24, seed);
        }

        [TestMethod]
        public void After250YearsShouldBeLessThan51()
        {
            var days = 365 * 250;
            var seed = Random.Next();

            var height = TreeCalculator.CalculateHeight(days, seed);

            Assert.That.Between(height, 13, 5100, seed);
        }
    }
}
