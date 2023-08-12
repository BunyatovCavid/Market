using Market.Domain.Entities;
using Market.Domain.Entities.Cross;
using Microsoft.EntityFrameworkCore;

namespace Market.Domain
{
    public class MarketDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Bonus_Card> Bonus_Cards { get; set; }
        public DbSet<Bonus_Card_Report> Bonus_Card_Reports { get; set; }
        public DbSet<Discount_Card> Discount_Cards { get; set; }
        public DbSet<Discount_Card_Report> Discount_Card_Reports { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Company_Report> Company_Reports { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Sub_Category> Sub_Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Paper> Papers { get; set; }
        public DbSet<Included> Includeds { get; set; }
        public DbSet<Cash> Cashes { get; set; }
        public DbSet<Check> Checks { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=WIN-PFGV5N8DK24;Database=Market;Trusted_Connection=True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Account
            modelBuilder.Entity<Account>()
                .HasMany(a => a.Bonus_Cards)
                .WithOne(b => b.Account)
                .HasForeignKey(b => b.AccountId);


            modelBuilder.Entity<Account>()
                .HasMany(a => a.Bonus_Card_Reports)
                .WithOne(b => b.Account)
                .HasForeignKey(b => b.AccountId);


            modelBuilder.Entity<Account>()
                .HasMany(a => a.Categorys)
                .WithOne(b => b.Account)
                .HasForeignKey(b => b.AccountId);


            modelBuilder.Entity<Account>()
                .HasMany(a => a.Checks)
                .WithOne(b => b.Account)
                .HasForeignKey(b => b.AccountId);


            modelBuilder.Entity<Account>()
                .HasMany(a => a.Companies)
                .WithOne(b => b.Account)
                .HasForeignKey(b => b.AccountId);


            modelBuilder.Entity<Account>()
                .HasMany(a => a.Company_Reports)
                .WithOne(b => b.Account)
                .HasForeignKey(b => b.AccountId);


            modelBuilder.Entity<Account>()
                .HasMany(a => a.Discount_Cards)
                .WithOne(b => b.Account)
                .HasForeignKey(b => b.AccountId);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.Discount_Card_Reports)
                .WithOne(b => b.Account)
                .HasForeignKey(b => b.AccountId);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.Items)
                .WithOne(b => b.Account)
                .HasForeignKey(b => b.AccountId);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.Papers)
                .WithOne(b => b.Account)
                .HasForeignKey(b => b.AccountId);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.Sub_Categories)
                .WithOne(b => b.Account)
                .HasForeignKey(b => b.AccountId);
            #endregion

            #region Cross_Account_Role
            modelBuilder.Entity<Cross_Account_Role>()
                 .HasKey(k => new {k.AccountId,k.RoleId });

            modelBuilder.Entity<Cross_Account_Role>()
                .HasOne(c=>c.Account)
                .WithMany(a=>a.Cross_Account_Role)
                .HasForeignKey(c=>c.AccountId);

            modelBuilder.Entity<Cross_Account_Role>()
                .HasOne(c => c.Role)
                .WithMany(r=>r.Cross_Account_Role)
                .HasForeignKey(c=>c.RoleId);
            #endregion

            #region Bonus_Card
            modelBuilder.Entity<Bonus_Card>()
                .HasIndex(b=>b.Barkod)
                .IsUnique();


            modelBuilder.Entity<Bonus_Card>()
                .HasMany(dc => dc.Bonus_Card_Report)
                .WithOne(dcr => dcr.Bonus_Card)
                .HasForeignKey(dc => dc.Bonus_CardId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Discount_Card
            modelBuilder.Entity<Discount_Card>()
                .HasIndex(dc => dc.Barkod)
                .IsUnique();

            modelBuilder.Entity<Discount_Card>()
                .HasAlternateKey(dc=>dc.Fin);

            modelBuilder.Entity<Discount_Card>()
                .HasMany(dc => dc.Discount_Card_Reports)
                .WithOne(dcr => dcr.Discount_Card)
                .HasForeignKey(dc => dc.Discount_CardId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Company
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Company_Report)
                .WithOne(cr => cr.Company)
                .HasForeignKey(cr=>cr.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Category
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Sub_Categories)
                .WithOne(sc => sc.Category)
                .HasForeignKey(sc => sc.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Item
            modelBuilder.Entity<Item>()
                .HasIndex(i => i.Barkod)
                .IsUnique();

            modelBuilder.Entity<Item>()
                .HasAlternateKey(i => i.Name);

            modelBuilder.Entity<Item>()
                .HasOne(i => i.Category)
                .WithMany(c => c.Items)
                .HasForeignKey(i=>i.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Item>()
             .HasOne(i => i.Company)
             .WithMany(c => c.Items)
             .HasForeignKey(i => i.CompanyId)
             .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Item>()
             .HasOne(i => i.Sub_Category)
             .WithMany(c => c.Items)
             .HasForeignKey(i => i.Sub_CategoryId)
             .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Item>()
                .HasOne(i => i.Included)
                .WithOne(I => I.Item)
                .HasForeignKey<Included>(In=>In.ItemId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Item>()
                .HasOne(i => i.Sale)
                .WithOne(I => I.Item)
                .HasForeignKey<Sale>(In => In.ItemId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Item>()
                .HasOne(i => i.Discount_Card_Report)
                .WithOne(d => d.Item)
                .HasForeignKey<Discount_Card_Report>(d => d.ItemId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Paper
            modelBuilder.Entity<Paper>()
                .HasMany(p => p.Includeds)
                .WithOne(i => i.Paper)
                .HasForeignKey(i => i.PaperId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Paper>()
                .HasAlternateKey(p => p.Paper_Number);
            #endregion

            #region Cash
            modelBuilder.Entity<Cash>()
                .HasAlternateKey(c => c.Number);

            modelBuilder.Entity<Cash>()
                .HasMany(c => c.Checks)
                .WithOne(ch => ch.Cash)
                .HasForeignKey(ch => ch.CashId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Check
            modelBuilder.Entity<Check>()
                .HasMany(c => c.Sales)
                .WithOne(s => s.Check)
                .HasForeignKey(s => s.CheckId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Check>()
                .HasOne(c => c.Bonus_Card)
                .WithOne(b => b.Check)
                .HasForeignKey<Check>(c => c.Bonus_CardId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Check>()
                .HasOne(c => c.Discount_Card)
                .WithOne(b => b.Check)
                .HasForeignKey<Check>(c => c.Discount_CardId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

        }
    }
}
