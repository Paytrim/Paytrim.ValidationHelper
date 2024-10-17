using System;
using System.Globalization;
using System.Linq;

namespace Paytrim.ValidationHelper
{
    //Source: https://skatteverket.se/privat/folkbokforing/personnummerochsamordningsnummer.4.3810a01c150939e893f18c29.html
    public class Personnummer
    {
        private string _personnummer;
        private DateTime _dateOfBirth;

        public bool IsSamordningsnummer { get; private set; }
        public DateTime DateOfBirth { get { return _dateOfBirth.Date; } }

        public Personnummer(string personnummer)
        {
            var onlyNumbers = new string(personnummer.Where(c => c >= '0' && c <= '9').ToArray());
            Parse(onlyNumbers, out _dateOfBirth, out bool isSamordningsnummer);
            _personnummer = personnummer;
            IsSamordningsnummer = isSamordningsnummer;
        }

        public static bool TryParse(string personnummer)
        {
            try
            {
                var onlyNumbers = new string(personnummer.Where(c => c >= '0' && c <= '9').ToArray());
                Parse(onlyNumbers, out _, out _);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            return _personnummer;
        }

        public string ToString(int length)
        {
            if (length < 10 || length > 13)
            {
                throw new ApplicationException("Use length 10-13 for different formats of '(cc)yymmdd(-)nnnn'");
            }
            var yearMonth = length switch
            {
                10 or 11 => _dateOfBirth.ToString("yyMM"),
                _ => _dateOfBirth.ToString("yyyyMM"),
            };
            var day = (IsSamordningsnummer ? _dateOfBirth.Day + 60 : _dateOfBirth.Day).ToString("00");
            var separator = length switch
            {
                10 or 12 => string.Empty,
                _ => (DateTime.UtcNow.AddYears(-100).Year < _dateOfBirth.Year) ? "-" : "+"
            };
            var number = _personnummer[^4..];
            return $"{yearMonth}{day}{separator}{number}";
        }

        private static void Parse(string personnummer, out DateTime dateOfBirth, out bool isSamordningsnummer)
        {
            if ((personnummer.Length != 12 && personnummer.Length != 10))
            {
                throw new ApplicationException($"'{personnummer}' is not formated correctly '(cc)yymmdd(-)nnnn'");
            }

            var century = personnummer.Length == 12 ? personnummer.Substring(0, 2) : GuessCentury(personnummer);
            if (personnummer.Length == 12)
            {
                personnummer = personnummer.Substring(2, 10);
            }

            isSamordningsnummer = false;
            var day = personnummer.Substring(4, 2);
            var dayInt = int.Parse(day);
            if (dayInt - 60 > 0)
            {
                isSamordningsnummer = true;
                int realDay = dayInt - 60;
                day = realDay < 10 ? $"0{realDay}" : realDay.ToString();
            }

            var yearMonth = personnummer.Substring(0, 4);
            if (!DateTime.TryParseExact($"{century}{yearMonth}{day}", "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateOfBirth))
            {
                throw new ApplicationException($"'{personnummer}' is not formated correctly '(cc)yymmdd(-)nnnn'");
            }

            var calculatedChecksum = LuhnAlgorithm.Run(personnummer.Substring(0, 9));
            int checksum = (int)char.GetNumericValue(personnummer.Last());
            if (calculatedChecksum != checksum)
            {
                throw new ApplicationException($"Checksum:'{checksum}' is not correct");
            }
        }

        /// <summary>
        /// Assumes birth this or last century, and age max 100 years
        /// </summary>
        /// <param name="personnummer"></param>
        /// <returns></returns>
        private static string GuessCentury(string personnummer)
        {
            var centuryNow = DateTime.UtcNow.Year.ToString();
            var year = int.Parse(personnummer.Substring(0, 2));
            int thiscentury = int.Parse(centuryNow.Substring(0, 2));
            var thisYear = int.Parse(centuryNow.Substring(2, 2));
            return year <= thisYear ? $"{thiscentury}" : $"{thiscentury - 1}";
        }
    }
}
