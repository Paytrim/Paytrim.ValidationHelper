using System;
using Xunit;

namespace Paytrim.ValidationHelper.Tests
{
    public class SwedishBankAccountTests
    {
        [Theory]
        [InlineData("6789123456789", "6789", "123456789", "Handelsbanken")]
        [InlineData("8351-9,392 242 224-5", "83519", "3922422245", "Swedbank")]
        [InlineData("8129-9,043 386 711-6", "81299", "0433867116", "Swedbank")]
        [InlineData("3300 000620-5124", "3300", "0006205124", "Nordea")]
        [InlineData("9420, 417 23 85", "9420", "4172385", "Forex Bank")]
        [InlineData("97891111113", "9789", "1111113", "Klarna Bank")]
        [InlineData("8424-4,983 189 224-6", "84244", "9831892246", "Swedbank")]
        [InlineData("8322-1, 987 654 321-0", "83221", "9876543210", "Swedbank")]
        [InlineData("9552-1361377", "9552", "1361377", "Avanza Bank")]
        [InlineData("5304 02 878 50", "5304", "0287850", "SEB")]
        public void SwedishBankAccount_Positive(string completeAccount, string clearingNumber, string accountNumber, string name)
        {
            var swedishBankAccount = new SwedishBankAccount(completeAccount);

            Assert.Equal(clearingNumber, swedishBankAccount.ClearingNumber);
            Assert.Equal(accountNumber, swedishBankAccount.AccountNumber);
            Assert.Equal(name.ToLower(), swedishBankAccount.SwedishBank.Name.ToLower());
        }

        [Theory]
        [InlineData("123456789")] // invalid completly
        [InlineData("6789123456788")] // valid number, invalid checksum
        [InlineData("8424-1,983 189 224-6")] // invalid swedbank clearing
        public void SwedishBankAccount_Negative(string completeAccount)
        {
            Assert.Throws<ApplicationException>(() => new SwedishBankAccount(completeAccount));
        }

        [Theory]
        [InlineData("6789123456789", true)]
        [InlineData("6789123456788", false)]
        public void SwedishBankAccountTryParse_ShouldReturn(string completeAccount, bool isOk)
        {
            Assert.Equal(isOk, SwedishBankAccount.TryParse(completeAccount));
        }
    }
}
