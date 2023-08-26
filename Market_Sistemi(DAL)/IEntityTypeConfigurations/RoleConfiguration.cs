using Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Market.IEntityTypeConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(a=>a.Name).HasMaxLength(10).IsRequired();
            builder.HasData(new Role() { Id =1, Name = "Developer"});
        }
    }
}
