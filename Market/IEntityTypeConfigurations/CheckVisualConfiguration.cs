using Market.Domain.Entities.Visuals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Market.IEntityTypeConfigurations
{
    public class CheckVisualConfiguration : IEntityTypeConfiguration<CheckVisual>
    {
        public void Configure(EntityTypeBuilder<CheckVisual> builder)
        {
            builder.Property(a => a.CheckNumber).IsRequired();
            builder.Property(a => a.CashId).IsRequired();

            builder.HasMany(c => c.SaleVisuals)
               .WithOne(s => s.CheckVisual)
               .HasForeignKey(s => s.CheckVisualId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
