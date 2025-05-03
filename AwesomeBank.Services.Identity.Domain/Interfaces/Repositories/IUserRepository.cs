using AwesomeBank.Services.Identity.Domain.Entities;

namespace AwesomeBank.Services.Identity.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> GetByEmailAndPasswordAsync(string email, string password);
        Task SaveChangesAsync();
    }
}