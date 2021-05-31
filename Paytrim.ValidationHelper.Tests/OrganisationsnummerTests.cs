using System;
using Xunit;

namespace Paytrim.ValidationHelper.Tests
{
    public class OrganisationsnummerTests
    {
        [Theory]
        [InlineData("2120000142")] // stad
        [InlineData("5560360793")] // AB
        [InlineData("9401097218")] // enskild firma
        [InlineData("9696676312")] // kommanditbolag
        [InlineData("9697071984")] // handelsbolag
        [InlineData("2520026135")] // trossamfund
        [InlineData("7164167939")] // brf
        [InlineData("8020052083")] // stiftelse
        [InlineData(" 556036-0793 ")]
        public void Organisationsnummer_Positive(string organisationsnummer)
        {
            Assert.NotNull(new Organisationsnummer(organisationsnummer));
        }
        
        [Theory]
        [InlineData("55603607931")] //long
        [InlineData("556036079")] //short
        [InlineData("55603607933")] //checksum
        [InlineData("-55603607931")] //digits
        public void Organisationsnummer_WrongFormat_ShouldThrow(string organisationsnummer)
        {
            Assert.Throws<ApplicationException>(() => new Organisationsnummer(organisationsnummer));
        }

        [Theory]
        [InlineData("5560360793", true)]
        [InlineData("5560360792", false)]
        [InlineData(" 556036-0793 ", true)]
        public void OrganisationsnummerTryParse_ShouldReturn(string organisationsnummer, bool isOk)
        {
            Assert.Equal(isOk, Organisationsnummer.TryParse(organisationsnummer));
        }
    }
}
