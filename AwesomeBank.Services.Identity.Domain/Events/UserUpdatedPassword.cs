namespace AwesomeBank.Services.Identity.Domain.Events
{
    /// <summary>
    /// Represents a UserUpdatedPassword domain event.
    /// </summary>
    /// <param name="id">Id of the user.</param>
    /// <param name="fullName">Full name of the user.</param>
    /// <param name="email">Email of the user.</param>
    /// <returns></returns>
    public record UserUpdatedPassword(Guid id, string fullName, string email) : IDomainEvent
    {
        /// <summary>
        /// User id.
        /// </summary> <summary>
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
