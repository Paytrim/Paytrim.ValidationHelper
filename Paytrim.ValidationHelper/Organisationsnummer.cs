using System;
using System.Linq;

namespace Paytrim.ValidationHelper
{
    //Source: https://www4.skatteverket.se/rattsligvagledning/326447.html
    public class Organisationsnummer
    {
        private string _organisationsnummer;

        public Organisationsnummer(string organisationsnummer)
        {
            var onlyNumbers = new string(organisationsnummer.Where(c => c >= '0' && c <= '9').ToArray());
            Parse(onlyNumbers);
            _organisationsnummer = organisationsnummer;
        }
        public static bool TryParse(string organisationsnummer)
        {
            try
            {
                var onlyNumbers = new string(organisationsnummer.Where(c => c >= '0' && c <= '9').ToArray());
                Parse(onlyNumbers);
            }
            catch(Exception)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            return _organisationsnummer;
        }

        private static void Parse(string organisationsnummer)
        {
            if (organisationsnummer.Length != 10)
            {
                throw new ApplicationException($"'{organisationsnummer}' is not formated correctly (yymmddnnnn or nnnnnn(-)nnnn)");
            }

            if(int.Parse(organisationsnummer.Substring(2, 1)) <= 1)
            {
                Personnummer.TryParse(organisationsnummer);
            }
            else
            {
                var calculatedChecksum = LuhnAlgorithm.Run(organisationsnummer.Substring(0, 9));
                int checksum = (int)char.GetNumericValue(organisationsnummer.Last());
                if (calculatedChecksum != checksum)
                {
                    throw new ApplicationException($"Checksum:'{checksum}' is not correct");
                }
            }
        }
    }
}
