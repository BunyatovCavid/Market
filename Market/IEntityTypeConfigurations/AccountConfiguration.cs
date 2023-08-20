using Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Market.IEntityTypeConfigurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(a => a.Name).HasMaxLength(25).IsRequired();
            builder.Property(a => a.Password).HasMaxLength(15).IsRequired();
            builder.Property(a => a.Description).HasMaxLength(50);



            builder.HasMany(a => a.Bonus_Cards)
                .WithOne(b => b.Account)
                .HasForeignKey(b => b.AccountId);

            builder.HasMany(a => a.Bonus_Card_Reports)
                .WithOne(b => b.Account)
                .HasForeignKey(b => b.AccountId);


            builder.HasMany(a => a.Categorys)
                .WithOne(b => b.Account)
                .HasForeignKey(b => b.AccountId);


            builder.HasMany(a => a.Checks)
                .WithOne(b => b.Account)
                .HasForeignKey(b => b.AccountId);


            builder.HasMany(a => a.Companies)
                .WithOne(b => b.Account)
                .HasForeignKey(b => b.AccountId);


            builder.HasMany(a => a.Company_Reports)
                .WithOne(b => b.Account)
                .HasForeignKey(b => b.AccountId);


            builder.HasMany(a => a.Discount_Cards)
                .WithOne(b => b.Account)
                .HasForeignKey(b => b.AccountId);

            builder.HasMany(a => a.Items)
                .WithOne(b => b.Account)
                .HasForeignKey(b => b.AccountId);

            builder.HasMany(a => a.Papers)
                .WithOne(b => b.Account)
                .HasForeignKey(b => b.AccountId);

            builder.HasMany(a => a.Sub_Categories)
                .WithOne(b => b.Account)
                .HasForeignKey(b => b.AccountId);

        }


    }
}
