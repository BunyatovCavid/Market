using Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Market.IEntityTypeConfigurations
{
    public class Discount_CardConfiguration : IEntityTypeConfiguration<Discount_Card>
    {
        public void Configure(EntityTypeBuilder<Discount_Card> builder)
        {
            builder.Property(a => a.Name).HasMaxLength(25).IsRequired();
            builder.Property(a => a.Fin).HasMaxLength(10).IsRequired();
            builder.Property(a => a.Barkod).HasMaxLength(15).IsRequired();
            builder.Property(a => a.Phone).HasMaxLength(15).IsRequired();
            builder.Property(a => a.Description).HasMaxLength(12);
            builder.Property(a => a.AccountId).IsRequired();


            builder.HasIndex(dc => dc.Barkod)
                .IsUnique();

            builder.HasAlternateKey(dc => dc.Fin);
        }
    }
}
