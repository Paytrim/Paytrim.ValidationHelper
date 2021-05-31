using System;
using Xunit;

namespace Paytrim.ValidationHelper.Tests
{
    public class PersonnummerTests
    {
        [Theory]
        [InlineData("199401097218")]
        [InlineData("169401097218")]
        [InlineData("669401097218")]
        [InlineData("196811014395")]
        [InlineData("199803010280")]
        [InlineData("190110285079")]
        [InlineData("180110285079")]
        [InlineData("200110285079")]
        [InlineData(" 19940109-7218 ")]
        public void Personnummer_Positive(string personnummer)
        {
            Assert.NotNull(new Personnummer(personnummer));
        }

        [Theory]
        [InlineData("9401097218")]
        [InlineData("6811014395")]
        [InlineData("9803010280")]
        [InlineData("0110285079")]
        public void Personnummer_PositiveWithoutCentury(string personnummer)
        {
            Assert.NotNull(new Personnummer(personnummer));
        }

        [Theory]
        [InlineData("9803010280")]
        [InlineData("0110285079")]
        [InlineData("2105067637")]
        public void Personnummer_GuessCenturyShouldSetCenturySoPersonIsLessThan100YearsOld(string personnummer)
        {
            var pnr = new Personnummer(personnummer);           
            Assert.True(DateTime.UtcNow.Year - pnr.DateOfBirth.Year < 100);
        }

        [Theory]
        [InlineData("1199401097218")] //long
        [InlineData("401097218")] //short
        [InlineData("199401997218")] //day
        [InlineData("199413097218")] //month
        [InlineData("199401097217")] //checksum
        [InlineData("-99401097218")] //digits
        public void Personnummer_WrongFormat_ShouldThrow(string personnummer)
        {
            Assert.Throws<ApplicationException>(() => new Personnummer(personnummer));
        }

        [Theory]
        [InlineData("199401097218", true)]
        [InlineData("199401097217", false)]
        [InlineData(" 19940109-7218 ", true)]
        public void PersonnummerTryParse_ShouldReturn(string personnummer, bool isOk)
        {
            Assert.Equal(isOk, Personnummer.TryParse(personnummer));
        }

        [Theory]
        [InlineData("197010632391", true)]
        [InlineData("190110285079", false)]
        public void Personnummer_ShoulSetCorrectSamordningsnummer(string personnummer, bool samordningsnummer)
        {
            var pnr = new Personnummer(personnummer);
            Assert.Equal(samordningsnummer, pnr.IsSamordningsnummer);
        }

        [Theory]
        [InlineData("197010632391", 1970, 10, 3)] //samordningsnummer
        [InlineData("199401097218", 1994, 1, 9)]
        public void Personnummer_ShoulSetCorrectDateOfBirth(string personnummer, int year, int month, int day)
        {
            var date = new DateTime(year, month, day);
            var pnr = new Personnummer(personnummer);
            Assert.Equal(date, pnr.DateOfBirth);
        }
    }
}
