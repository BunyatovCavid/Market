using Market.Domain.Entities.Visuals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Market.IEntityTypeConfigurations
{
    public class SaleVisualConfiguration : IEntityTypeConfiguration<SaleVisual>
    {
        public void Configure(EntityTypeBuilder<SaleVisual> builder)
        {
            builder.HasOne(a => a.Item)
                 .WithOne(a => a.SaleVisual)
                 .HasForeignKey<SaleVisual>(a => a.ItemId);
        }
    }
}
