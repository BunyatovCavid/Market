using Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Market.IEntityTypeConfigurations
{
    public class Bonus_Card_ReportConfiguration : IEntityTypeConfiguration<Bonus_Card_Report>
    {
        public void Configure(EntityTypeBuilder<Bonus_Card_Report> builder)
        {
            builder.Property(a => a.Bonus_CardId).IsRequired();
            builder.Property(a => a.Description).HasMaxLength(50);
            builder.Property(a => a.AccountId).IsRequired();
        }
    }
}
