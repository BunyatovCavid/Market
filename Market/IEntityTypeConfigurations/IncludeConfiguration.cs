using Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Market.IEntityTypeConfigurations
{
    public class IncludeConfiguration : IEntityTypeConfiguration<Included>
    {
        public void Configure(EntityTypeBuilder<Included> builder)
        {
            builder.Property(a => a.ItemId).IsRequired();
            builder.Property(a => a.PaperId).IsRequired();
        }
    }
}
