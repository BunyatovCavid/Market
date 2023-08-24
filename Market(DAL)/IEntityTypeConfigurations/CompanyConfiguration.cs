using Microsoft.EntityFrameworkCore;
using Market.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Market.IEntityTypeConfigurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {

            builder.Property(a => a.Name).HasMaxLength(25).IsRequired();
            builder.Property(a => a.Description).HasMaxLength(12);
            builder.Property(a => a.AccountId).IsRequired();



        }
    }
}
