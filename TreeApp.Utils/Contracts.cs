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
    }
}
