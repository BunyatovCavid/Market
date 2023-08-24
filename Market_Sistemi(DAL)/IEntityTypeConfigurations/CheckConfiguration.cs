using Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Market.IEntityTypeConfigurations
{
    public class CheckConfiguration
    {
        public void Configure(EntityTypeBuilder<Check> builder)
        {

            builder.Property(a => a.Description).HasMaxLength(12);
            builder.Property(a => a.AccountId).IsRequired();

            builder.HasMany(c => c.Sales)
                .WithOne(s => s.Check)
                .HasForeignKey(s => s.CheckId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(c => c.Bonus_Card)
                 .WithOne(b => b.Check)
                 .HasForeignKey<Check>(c => c.Bonus_CardId)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Discount_Card)
                 .WithOne(b => b.Check)
                 .HasForeignKey<Check>(c => c.Discount_CardId)
                 .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
