namespace AwesomeBank.Services.Identity.Domain.Enums
{
    /// <summary>
    /// Enum that defines the role of the user.
    /// </summary>
    public enum UserRoleEnum
    {
        /// <summary>
        /// Common user who can perform and receive transactions.
        /// </summary>
        Customer = 0,

        /// <summary>
        /// Merchant user who can only receive transactions.
        /// </summary>
        Merchant = 1
    }
}
