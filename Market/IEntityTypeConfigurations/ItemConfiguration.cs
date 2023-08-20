using Microsoft.EntityFrameworkCore;
using Market.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Market.IEntityTypeConfigurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.Property(a => a.Name).HasMaxLength(40).IsRequired();
            builder.Property(a => a.Barkod).HasMaxLength(15).IsRequired();
            builder.Property(a => a.Number).HasMaxLength(10).IsRequired();
            builder.Property(a => a.Description).HasMaxLength(12);
            builder.Property(a => a.AccountId).IsRequired();

            builder.HasIndex(i => i.Barkod)
                 .IsUnique();

            builder.HasAlternateKey(i => i.Name);

            builder.HasOne(i => i.Category)
                 .WithMany(c => c.Items)
                 .HasForeignKey(i => i.CategoryId)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(i => i.Company)
              .WithMany(c => c.Items)
              .HasForeignKey(i => i.CompanyId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(i => i.Sub_Category)
              .WithMany(c => c.Items)
              .HasForeignKey(i => i.Sub_CategoryId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(i => i.Included)
                 .WithOne(I => I.Item)
                 .HasForeignKey<Included>(In => In.ItemId)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(i => i.Sale)
                 .WithOne(I => I.Item)
                 .HasForeignKey<Sale>(In => In.ItemId)
                 .OnDelete(DeleteBehavior.NoAction);
  
        }
    }
}
