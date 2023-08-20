using Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Market.IEntityTypeConfigurations
{
    public class PaperConfiguration : IEntityTypeConfiguration<Paper>
    {
        public void Configure(EntityTypeBuilder<Paper> builder)
        {

            builder.Property(a => a.Description).HasMaxLength(12);
            builder.Property(a => a.AccountId).IsRequired();
            builder.Property(a => a.Status).HasMaxLength(10).IsRequired();

            builder.HasMany(p => p.Includeds)
                 .WithOne(i => i.Paper)
                 .HasForeignKey(i => i.PaperId)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasAlternateKey(p => p.Paper_Number);
        }
    }
}
