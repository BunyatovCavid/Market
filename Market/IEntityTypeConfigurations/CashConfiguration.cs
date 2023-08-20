using Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Market.IEntityTypeConfigurations
{
    public class CashConfiguration : IEntityTypeConfiguration<Cash>
    {
        public void Configure(EntityTypeBuilder<Cash> builder)
        {
            builder.Property(a => a.Number).HasMaxLength(2).IsRequired();
            builder.Property(a => a.Description).HasMaxLength(12);

            builder.HasAlternateKey(c => c.Number);

            builder.HasMany(c => c.Checks)
                  .WithOne(ch => ch.Cash)
                  .HasForeignKey(ch => ch.CashId)
                  .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
