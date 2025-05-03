using AwesomeBank.Services.Identity.Domain.Entities;
using AwesomeBank.Services.Identity.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AwesomeBank.Services.Identity.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AwesomeBankIdentityDbContext _dbContext;

        public UserRepository(AwesomeBankIdentityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(User user)
        {
            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User?> GetByEmailAndPasswordAsync(string email, string password)
        {
            return await _dbContext.Users
                .SingleOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}