using System;
using TreeApp.Utils;

namespace TreeApp.Core
{
    public static class TreeCalculator
    {
        private const int DaysInYear = 365;

        public static double CalculateHeight(int totalDays, int seed)
        {
            var random = new Random(seed);

            double height = 0;

            for (var year = 0; totalDays > 0; year++)
            {
                var (min, max) = GetYearRange(year);
                var coef = GetYearCoef(totalDays, out totalDays);
                height += coef * random.Next(min, max + 1);
            }

            return height;
        }

        public static (int min, int max) GetYearRange(int year)
        {
            Contracts.ArgumentCondition(year, y => y >= 0);
            if (year == 0)
            {
                return (3, 4);
            }
            else if (year <= 15)
            {
                return (10, 20);
            }
            else if (year > 15 && year < 250)
            {
                var coef = Math.Sin((year * 3 / (250.0 * 2)) * Math.PI);
                var min = 8 + (int)Math.Floor(8 * coef);
                var max = 17 + (int)Math.Floor(17 * coef);
                return (min, max);
            }
            else
            {
                return (0, 0);
            }
        }

        internal static double GetThickness(double height)
        {
            //  1.5 метра -> 5 см
            // 50 метров - 1 метр
            return height / 30;
        }

        internal static double GetWidth(double height, int seed)
        {
            var random = new Random(seed);
            var coef = random.NextDouble() * 0.35;
            return height * (0.5 + coef);
        }

        internal static double GetStartHeight(double height)
        {
            return height / 7;
        }

        internal static int GetBranchCount(double height, int seed)
        {
            var random = new Random(seed);
            var coef = 0.75 + random.NextDouble() * 0.25;
            return (int)Math.Round(height * coef / 10);
        }

        private static double GetYearCoef(int totalDays, out int rem)
        {
            if (totalDays >= DaysInYear)
            {
                rem = totalDays - DaysInYear;
                return 1.0;
            }
            else
            {
                rem = 0;
                return (double)totalDays / DaysInYear;
            }
        }
    }
}
