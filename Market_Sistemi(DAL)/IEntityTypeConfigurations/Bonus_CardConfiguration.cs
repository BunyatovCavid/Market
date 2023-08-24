using Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Market.IEntityTypeConfigurations
{
    public class Bonus_CardConfiguration : IEntityTypeConfiguration<Bonus_Card>
    {
        public void Configure(EntityTypeBuilder<Bonus_Card> builder)
        {

            builder.Property(a => a.Name).HasMaxLength(25).IsRequired();
            builder.Property(a => a.Barkod).HasMaxLength(15).IsRequired();
            builder.Property(a => a.Phone).HasMaxLength(15).IsRequired();
            builder.Property(a => a.Description).HasMaxLength(12);
            builder.Property(a => a.AccountId).IsRequired();



            builder.HasIndex(b => b.Barkod)
                 .IsUnique();


            builder.HasMany(dc => dc.Bonus_Card_Report)
                .WithOne(dcr => dcr.Bonus_Card)
                .HasForeignKey(dc => dc.Bonus_CardId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
