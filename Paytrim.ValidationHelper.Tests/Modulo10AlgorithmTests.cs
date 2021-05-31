using Xunit;

namespace Paytrim.ValidationHelper.Tests
{
    public class Modulo10AlgorithmTests
    {
        [Theory]
        [InlineData("3316812057492")]
        public void TestModulo10_positive(string input)
        {
            Assert.True(Modulo10Algorithm.Run(input));
        }

        [Theory]
        [InlineData("3316819057492")]
        public void TestModulo10_negative(string input)
        {
            Assert.False(Modulo10Algorithm.Run(input));
        }
    }
}
