using System.Reflection;
using AwesomeBank.Services.Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AwesomeBank.Services.Identity.Infrastructure.Persistence
{
    public class AwesomeBankIdentityDbContext : DbContext
    {
        public AwesomeBankIdentityDbContext(DbContextOptions<AwesomeBankIdentityDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
