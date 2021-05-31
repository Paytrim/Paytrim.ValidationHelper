using System.Linq;

namespace Paytrim.ValidationHelper
{
    /// <summary>
    /// Implementation of Luhn algorithm
    /// </summary>
    public static class LuhnAlgorithm
    {
        public static int Run(string input)
        {
            var sum = input
                .Reverse()
                .Select((cha, i) => (cha - 48) * (i % 2 == 0 ? 2 : 1))
                .Select(num => num > 9 ? 1 + num - 10 : num)
                .Sum();

            var rest = sum % 10;
            return rest == 0 ? 0 : 10 - rest;
        }
    }
}
