using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.VisualStudio.TestTools.UnitTesting
{
    internal static class AssertExtensions
    {
        public static void Between(this Assert assert, double value, double min, double max, int seed)
        {
            if (!(value >= min && value <= max))
            {
                throw new AssertFailedException($"Value: {value}, Seed: {seed}");
            }
        }
    }
}
