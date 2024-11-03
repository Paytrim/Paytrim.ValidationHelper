using Xunit;

namespace Paytrim.ValidationHelper.Tests 
{
    public class LuhnAlgorithmTests
    {
        [Theory]
        [InlineData("940109721", 8)]
        [InlineData("681101439", 5)]
        [InlineData("980301028", 0)]
        [InlineData("011028507", 9)]
        [InlineData("0", 0)]
        [InlineData("", 0)]
        public void LuhnAlgorithm_Positive(string numbers, int checksum)
        {
            int calculatedChecksum = LuhnAlgorithm.Run(numbers);
            Assert.Equal(checksum, calculatedChecksum);
        }
    }
}
