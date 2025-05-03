using AwesomeBank.Services.Identity.Domain.Enums;
using AwesomeBank.Services.Identity.Domain.Events;
using AwesomeBank.Services.Identity.Domain.ValueObjects;

namespace AwesomeBank.Services.Identity.Domain.Entities
{
    public class User : AggregateRoot
    {
        public User(
            string fullName,
            string email,
            string password,
            string document,
            UserRoleEnum role
        )
            : base()
        {
            FullName = fullName;
            Email = email;
            Password = password;
            Role = role;

            Document = DocumentFactory.Create(document);

            AddEvent(new UserCreated(Id, FullName, Email));
        }

        /// <summary>
        /// Gets or sets the full name for this user.
        /// </summary>
        public string FullName { get; private set; }

        /// <summary>
        /// Gets or sets the email address for this user.
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Gets or sets the birthdate for this user.
        /// </summary>
        public DateTime BirthDate { get; private set; }

        /// <summary>
        /// Gets or sets the password for this user.
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// Gets or sets the document number for this user.
        /// </summary>
        public Document Document { get; private set; }

        /// <summary>
        /// Gets or sets the role for this user.
        /// </summary>
        /// <remarks>
        /// Possible values: Common, Merchant
        /// </remarks>
        public UserRoleEnum Role { get; private set; }

        /// <summary>
        /// Gets or sets the last time the user logged in.
        /// </summary>
        /// <value></value>
        public DateTime? LastLoginAt { get; private set; }

        /// <summary>
        /// Updates user info.
        /// </summary>
        public void Update(string fullName, DateTime birthDate)
        {
            FullName = fullName;
            BirthDate = birthDate;

            AddEvent(new UserUpdated(Id, FullName, Email));
        }

        /// <summary>
        /// Updates the user password.
        /// </summary>
        /// <param name="newPassword">New password.</param>
        public void UpdatePassword(string newPassword)
        {
            Password = newPassword;

            AddEvent(new UserUpdatedPassword(Id, FullName, Email));
        }
    }
}
