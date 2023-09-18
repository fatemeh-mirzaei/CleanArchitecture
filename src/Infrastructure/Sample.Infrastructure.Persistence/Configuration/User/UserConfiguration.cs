using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Domain;

namespace Sample.Infrastructure.Persistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.UserName)
                   .IsRequired();

            builder.Property(p => p.FirstName)
                   .HasMaxLength(50);

            builder.Property(p => p.LastName)
                   .HasMaxLength(50);

            builder.Property(p => p.PhoneNumber)
                   .HasMaxLength(20);

            builder.Property(p => p.CreatedBy)
                   .HasMaxLength(100);

            builder.Property(p => p.LastModifiedBy)
                   .HasMaxLength(100);

            builder.Property(p => p.RegisterDate)
                   .HasDefaultValueSql("GetDate()");

            builder.Property(p => p.PasswordHash)
                .HasMaxLength(150);

            builder.Property(p => p.SecurityStamp)
                .HasMaxLength(150);

            builder.HasMany(e => e.UserRoles)
                    .WithOne(x => x.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();


        }
    }
}
