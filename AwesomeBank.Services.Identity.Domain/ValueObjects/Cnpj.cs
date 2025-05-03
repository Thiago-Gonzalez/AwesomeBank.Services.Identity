using System.Text.RegularExpressions;
using AwesomeBank.Services.Identity.Domain.Exceptions;

namespace AwesomeBank.Services.Identity.Domain.ValueObjects
{
    /// <summary>
    /// Represents a Document of type Cnpj.
    /// </summary>
    public record Cnpj : Document
    {
        public Cnpj(string number)
            : base(number)
        {
            if (!IsValid())
                throw new DomainException("Invalid Cnpj!");
        }

        /// <summary>
        /// Gets the number of the document masked.
        /// </summary>
        /// <returns>The number of the document masked.</returns>
        public override string GetMaskedNumber()
        {
            if (string.IsNullOrEmpty(OnlyNumbers))
                return string.Empty;

            if (OnlyNumbers.Length != 14)
                return OnlyNumbers;

            return $"{OnlyNumbers.Substring(0, 2)}.{OnlyNumbers.Substring(2, 3)}.{OnlyNumbers.Substring(5, 3)}/{OnlyNumbers.Substring(8, 4)}-{OnlyNumbers.Substring(12, 2)}";
        }

        /// <summary>
        /// Verifies if the Cnpj number is valid.
        /// </summary>
        /// <returns>True if the number is valid, otherwise false.</returns>
        public override bool IsValid()
        {
            var regex = new Regex(@"^\d{14}$");

            if (!regex.IsMatch(Number))
                return false;

            var firstVerifyingDigitWeight = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int sum = 0;
            for (int i = 0; i < 12; i++)
            {
                sum += int.Parse(Number[i].ToString()) * firstVerifyingDigitWeight[i];
            }

            int rest = sum % 11;
            int firstVerifyingDigit = rest < 2 ? 0 : 11 - rest;

            var secondVerifyingDigitWeight = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            sum = 0;
            for (int i = 0; i < 12; i++)
            {
                sum += int.Parse(Number[i].ToString()) * secondVerifyingDigitWeight[i];
            }

            sum += firstVerifyingDigit * secondVerifyingDigitWeight[12];

            rest = sum % 11;
            int secondVerifyingDigit = rest < 2 ? 0 : 11 - rest;

            return Number.EndsWith($"{firstVerifyingDigit}{secondVerifyingDigit}");
        }
    }
}
