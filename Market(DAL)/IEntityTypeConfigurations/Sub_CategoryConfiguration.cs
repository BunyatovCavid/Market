using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Market.Domain.Entities;


namespace Market.IEntityTypeConfigurations
{
    public class Sub_CategoryConfiguration:IEntityTypeConfiguration<Sub_Category>
    {
        public void Configure(EntityTypeBuilder<Sub_Category> builder)
        {
            builder.Property(a=>a.Description).HasMaxLength(50);
            builder.Property(a=>a.Name).HasMaxLength(20);
            builder.Property(a=>a.CategoryId).IsRequired();
            builder.Property(a => a.AccountId).IsRequired();
        }
    }
}
