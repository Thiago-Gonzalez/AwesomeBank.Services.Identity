namespace AwesomeBank.Services.Identity.Domain.ValueObjects
{
    /// <summary>
    /// Factory class for creating a <see cref="Document"/>.
    /// </summary>
    public static class DocumentFactory
    {
        /// <summary>
        /// Creates a <see cref="Document"/> as a <see cref="Cpf"/> or <see cref="Cnpj"/> based on its length.
        /// </summary>
        /// <param name="number">Number of the document.</param>
        /// <returns>A <see cref="Document"/> that can be a <see cref="Cpf"/> or a <see cref="Cnpj"/>.</returns>
        public static Document Create(string number)
        {
            var digitsOnly = new string([.. number.Where(char.IsDigit)]);

            return digitsOnly.Length switch
            {
                11 => new Cpf(digitsOnly),
                14 => new Cnpj(digitsOnly),
                _ => throw new ArgumentException("Invalid document.")
            };
        }
    }
}
