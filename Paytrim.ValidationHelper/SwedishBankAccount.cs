using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Paytrim.ValidationHelper
{
    // source: https://www.bankgirot.se/globalassets/dokument/anvandarmanualer/bankernaskontonummeruppbyggnad_anvandarmanual_sv.pdf
    public class SwedishBankAccount
    {
        public string ClearingNumber { get; private set; }
        public string AccountNumber { get; private set; }
        public SwedishBank SwedishBank { get; private set; }

        public SwedishBankAccount(string swedishBankAccountNumber)
        {
            Parse(swedishBankAccountNumber, out string clearingNumber, out string accountNumber, out SwedishBank swedishBank);
            ClearingNumber = clearingNumber;
            AccountNumber = accountNumber;
            SwedishBank = swedishBank;
        }

        public static bool TryParse(string swedishBankAccountNumber)
        {
            try
            {
                Parse(swedishBankAccountNumber, out _, out _, out _);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static void Parse(string completeNumber, out string clearingNumber, out string accountNumber, out SwedishBank swedishBank)
        {
            var number = new string(completeNumber.Where(c => c >= '0' && c <= '9').ToArray());

            // get the the clearing number
            clearingNumber = number.Substring(0, number.First().Equals('8') ? 5 : 4);
            accountNumber = string.Empty;

            //get the bank
            swedishBank = Banks.SwedishBanks.FirstOrDefault(x => Regex.IsMatch(number, x.Regex));
            if (swedishBank == null)
            {
                throw new ApplicationException("Could not match the account number to any known bank");
            }

            // get the account number
            accountNumber = ParseAccountNumber(swedishBank, number);

            //Type 1
            //The account number consists of a total of eleven digits – the clearing number and the
            //actual account number, including a check digit(C) according to Modulus - 11, using the
            //weights 1, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1

            //Comment 1
            //Checksum calculation is made on the Clearing number with the exception of the first digit,
            //and seven digits of the actual account number.
            if (swedishBank.Type == 1 && swedishBank.Comment == 1)
            {
                var input = clearingNumber.Substring(1, clearingNumber.Length - 1) + accountNumber;
                if(!Modulo11Algorithm.Run(input))
                {
                    throw new ApplicationException("Checksum calculation failed");
                }
            }

            //Checksum calculation is made on the entire Clearing number, and seven digits of the actual
            //account number.
            else if (swedishBank.Type == 1 && swedishBank.Comment == 2)
            {
                if(!Modulo11Algorithm.Run(clearingNumber + accountNumber))
                {
                    throw new ApplicationException("Checksum calculation failed");
                }
            }

            //Type 2
            //The Clearing number is not part of the Bank Account number.
            //Significant digits in the Account Number Field are designating the Account Number.

            //comment 1
            //Th account number consistof 10 digits.Checksum calculation uses the last ten digits using
            //the modulus 10 check, according format for account number (clearing number not
            //included).
            else if (swedishBank.Type == 2 && swedishBank.Comment == 1)
            {
                if(!Modulo10Algorithm.Run(accountNumber))
                {
                    throw new ApplicationException("Checksum calculation failed");
                }
            }

            //Comment 2
            //Checksum consists of 9 digits. Checksum calculation uses the 9 last digits using the modulus
            //11 check.
            else if (swedishBank.Type == 2 && swedishBank.Comment == 2)
            {
                if(!Modulo11Algorithm.Run(accountNumber))
                {
                    throw new ApplicationException("Checksum calculation failed");
                }
            }

            //comment 3
            //The account number consists of 10 digits.Checksum calculation uses the last ten digits using
            //the modulus 10 check, according format for account number (clearing number not
            //included). However in rare occasions some of Swedbank’s accounts cannot be validated by
            //a checksum calculation.
            else if (Modulo10Algorithm.Run(accountNumber) && clearingNumber.First().Equals('8')) //some won't match this 
            {
                if(!Modulo10Algorithm.Run(clearingNumber))
                {
                    throw new ApplicationException("Checksum calculation failed");
                }
            }
            // there are numbers that cannot be matched, but that's ok
        }

        public static string ParseAccountNumber(SwedishBank swedishBank, string number)
        {
            string account;

            // All accounts of type 1
            if (swedishBank.Type == 1)
            {
                account = number.Substring(number.Length - 7, 7);
            }
            // Handelsbankens accounts of type 2
            else if (swedishBank.Type == 2 && swedishBank.Comment == 2)
            {
                account = number.Substring(number.Length - 9, 9);
            }
            // Swedbanks accounts of type 2
            else if (swedishBank.Type == 2 && swedishBank.Comment == 3 && number.First().Equals('8'))
            {
                account = number.Substring(5, number.Length - 5);
            }
            // Plusgirots accounts of type 2
            else if (swedishBank.Type == 2 && swedishBank.Comment == 3 && number.First().Equals('9'))
            {
                account = number.Substring(4, number.Length - 4);
            }
            // Remaining accounts of type 2
            else
            {
                account = number.Substring(number.Length - 10, 10);
            }
            return account;
        }
    }
}
