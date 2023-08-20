using Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Market.IEntityTypeConfigurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.Property(a => a.ItemId).IsRequired();
            builder.Property(a => a.CheckId).IsRequired();
            builder.Property(a => a.Number).HasMaxLength(5);
            builder.Property(a => a.Description).HasMaxLength(50);
        }
    }
}
