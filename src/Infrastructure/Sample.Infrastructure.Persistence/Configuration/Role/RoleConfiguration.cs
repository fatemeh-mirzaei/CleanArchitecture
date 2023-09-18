using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Domain;

namespace Sample.Infrastructure.Persistence.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(p => p.Title).HasMaxLength(100);

            builder.Property(p => p.CreatedBy).HasMaxLength(100);

            builder.Property(p => p.LastModifiedBy).HasMaxLength(100);

            builder.HasMany(e => e.UserRoles)
                 .WithOne(x => x.Role)
                 .HasForeignKey(r => r.RoleId)
                 .IsRequired();

        }

    }
}
