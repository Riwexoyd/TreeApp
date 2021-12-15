using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Diagnostics;

namespace TreeApp.Core.Tests.TreeCalculatorTests
{
    [TestClass]
    public class GetYearRangeTest
    {
        [TestMethod]
        public void MaxAndMinHeightShouldBeInRange()
        {
            int min = 0;
            int max = 0;
            for (var year = 0; year <= 250; year++)
            {
                var (minVal, maxVal) = TreeCalculator.GetYearRange(year);
                min += minVal;
                max += maxVal;
                Debug.WriteLine($"For {year + 1}, min: {min}, max: {max}");
            }

            Assert.IsTrue(max <= 5100);
            Assert.IsTrue(max >= 4900);
            Assert.IsTrue(min >= 2000);
            Assert.IsTrue(min <= 2500);
        }
    }
}
