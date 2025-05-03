using System.Text.RegularExpressions;
using AwesomeBank.Services.Identity.Domain.Exceptions;

namespace AwesomeBank.Services.Identity.Domain.ValueObjects
{
    /// <summary>
    /// Represents a Document of type Cpf.
    /// </summary>
    public record Cpf : Document
    {
        public Cpf(string number)
            : base(number)
        {
            if (!IsValid())
                throw new DomainException("Invalid Cpf!");
        }

        /// <summary>
        /// Gets the number of the document masked.
        /// </summary>
        /// <returns>The number of the document masked.</returns>
        public override string GetMaskedNumber()
        {
            if (string.IsNullOrEmpty(OnlyNumbers))
                return string.Empty;

            if (OnlyNumbers.Length != 11)
                return OnlyNumbers;

            return $"{OnlyNumbers.Substring(0, 3)}.{OnlyNumbers.Substring(3, 3)}.{OnlyNumbers.Substring(6, 3)}-{OnlyNumbers.Substring(9, 2)}";
        }

        /// <summary>
        /// Verifies if the Cpf number is valid.
        /// </summary>
        /// <returns>True if the number is valid, otherwise false.</returns>
        public override bool IsValid()
        {
            var regex = new Regex(@"^\d{3}\d{3}\d{3}\d{2}$");

            if (!regex.IsMatch(Number))
                return false;

            if (Number.All(d => d == Number[0]))
                return false;

            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(Number[i].ToString()) * (10 - i);
            }

            int rest = sum % 11;
            int firstVerifyingDigit = (rest < 2) ? 0 : (11 - rest);

            if (firstVerifyingDigit != int.Parse(Number[9].ToString()))
                return false;

            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += int.Parse(Number[i].ToString()) * (11 - i);
            }

            rest = sum % 11;
            int secondVerifyingDigit = (rest < 2) ? 0 : (11 - rest);

            if (secondVerifyingDigit != int.Parse(Number[10].ToString()))
                return false;

            return true;
        }
    }
}
