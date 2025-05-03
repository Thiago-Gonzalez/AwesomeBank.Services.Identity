namespace AwesomeBank.Services.Identity.Domain.Exceptions
{
    /// <summary>
    /// Represents a domain exception.
    /// </summary>
    public class DomainException : Exception
    {
        public DomainException(string message)
            : base(message) { }
    }
}
