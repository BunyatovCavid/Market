using Market.Domain.Entities.Cross;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Market.IEntityTypeConfigurations
{
    public class Cross_Account_RoleConfiguration : IEntityTypeConfiguration<Cross_Account_Role>
    {
        public void Configure(EntityTypeBuilder<Cross_Account_Role> builder)
        {
            builder.Property(a => a.AccountId).IsRequired();
            builder.Property(a => a.RoleId).IsRequired();

            builder.HasKey(k => new { k.AccountId, k.RoleId });

            builder.HasOne(c => c.Account)
                .WithMany(a => a.Cross_Account_Role)
                .HasForeignKey(c => c.AccountId);

            builder.HasOne(c => c.Role)
                .WithMany(r => r.Cross_Account_Role)
                .HasForeignKey(c => c.RoleId);

        }
    }
}
