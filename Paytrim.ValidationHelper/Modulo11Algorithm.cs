using System;
using System.Linq;

namespace Paytrim.ValidationHelper
{
    /// <summary>
    /// Implementation of Modulo11 algorithm
    /// </summary>
    public static class Modulo11Algorithm
    {
        public static bool Run(string input)
        {
            var sum = input
                .Reverse()
                .Select((cha, i) => (cha - 48) * (i + 1 > 10 ? i + 1 - 10 : i + 1))
                .Sum();

            return sum % 11 == 0;
        }
    }
}
