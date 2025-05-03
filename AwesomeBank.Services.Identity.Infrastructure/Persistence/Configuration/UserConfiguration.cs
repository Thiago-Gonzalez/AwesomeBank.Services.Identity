using AwesomeBank.Services.Identity.Domain.Entities;
using AwesomeBank.Services.Identity.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AwesomeBank.Services.Identity.Infrastructure.Persistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.FullName)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(150);

            builder
                .Property(x => x.BirthDate)
                .IsRequired();

            builder
                .Property(x => x.Document)
                .IsRequired()
                .HasMaxLength(14)
                .HasConversion(
                    d => d.Number,
                    s => DocumentFactory.Create(s)
                );

            builder
                .Property(x => x.Role)
                .IsRequired();

            builder
                .Property(x => x.Active)
                .IsRequired()
                .HasDefaultValue(true);

            builder
                .Property(x => x.CreatedAt)
                .IsRequired();

            builder
                .Property(x => x.LastLoginAt)
                .IsRequired(false);

            builder.HasIndex(x => x.Email)
                .IsUnique()
                .HasDatabaseName("IX_Users_Email");

            builder.HasIndex(x => x.Document)
                .IsUnique()
                .HasDatabaseName("IX_Users_Document");

            builder.HasQueryFilter(x => x.Active);
        }
    }
}
