using System;
using System.Linq;

namespace Paytrim.ValidationHelper
{
    /// <summary>
    /// Implementation of Modulo10 algorithm
    /// </summary>
    public static class Modulo10Algorithm
    {
        public static bool Run(string input)
        {
            int sum = input
                .Reverse()
                .Select((cha, i) => (cha - 48) * (i % 2 != 0 ? 2 : 1))
                .Select(num => num > 9 ? 1 + num - 10 : num)
                .Sum();

            return sum % 10 == 0;
        }
    }
}
