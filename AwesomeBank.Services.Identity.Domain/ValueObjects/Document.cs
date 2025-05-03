namespace AwesomeBank.Services.Identity.Domain.ValueObjects
{
    public abstract record Document
    {
        public Document(string number)
        {
            Number = number;
        }

        public string Number { get; protected set; }

        public string MaskedNumber => GetMaskedNumber();

        public string OnlyNumbers => new([.. Number.Where(char.IsDigit)]);

        public abstract bool IsValid();

        public abstract string GetMaskedNumber();
    }
}
