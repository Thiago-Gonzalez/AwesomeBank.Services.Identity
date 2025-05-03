namespace AwesomeBank.Services.Identity.Domain.Events
{
    /// <summary>
    /// Represents a UserCreated domain event.
    /// </summary>
    public record UserCreated(Guid id, string fullName, string email) : IDomainEvent
    {
        /// <summary>
        /// User id.
        /// </summary>
        public Guid Id { get; } = id;

        /// <summary>
        /// User full name.
        /// </summary>
        public string FullName { get; } = fullName;

        /// <summary>
        /// User email address.
        /// </summary>
        public string Email { get; } = email;
    }
}
