using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Domain;

namespace Sample.Infrastructure.Persistence.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.Property(p => p.CreatedBy).HasMaxLength(100);

            builder.Property(p => p.LastModifiedBy).HasMaxLength(100);

            builder.HasDiscriminator().HasValue("UserRole");


        }
    }
}
