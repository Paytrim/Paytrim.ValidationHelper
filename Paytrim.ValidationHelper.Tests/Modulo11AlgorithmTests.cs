using Xunit;

namespace Paytrim.ValidationHelper.Tests
{
    public class Modulo11AlgorithmTests
    {
        [Theory]
        [InlineData("1912763608957")]
        [InlineData("324558")]
        [InlineData("241350")]
        public void TestModulo11_positive(string input)
        {
            Assert.True(Modulo11Algorithm.Run(input));
        }

        [Theory]
        [InlineData("241352")]
        public void TestModulo11_negative(string input)
        {
            Assert.False(Modulo11Algorithm.Run(input));

        }
    }
}
