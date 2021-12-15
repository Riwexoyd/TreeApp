using System;

namespace TreeApp.Utils
{
    public static class Contracts
    {
        public static void ThrowIfNull(object arg, string paramName)
        {
            if (arg == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        public static void ArgumentCondition<T>(T argument, Func<T, bool> condition)
        {
            if (!condition(argument))
            {
                throw new ArgumentException("Invalid argument value", nameof(argument));
            }
        }
    }
}
