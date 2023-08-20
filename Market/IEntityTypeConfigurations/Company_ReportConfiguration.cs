using Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Market.IEntityTypeConfigurations
{
    public class Company_ReportConfiguration : IEntityTypeConfiguration<Company_Report>
    {
        public void Configure(EntityTypeBuilder<Company_Report> builder)
        {
            builder.Property(a=>a.CompanyId).IsRequired();
            builder.Property(a=>a.Description).HasMaxLength(12);
            builder.Property(a => a.AccountId).IsRequired();
        }
    }
}
