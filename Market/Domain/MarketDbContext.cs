using Market.Domain.Entities;
using Market.Domain.Entities.Cross;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Market.Domain
{
    public class MarketDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Cross_Account_Role> Cross_Account_Role { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Bonus_Card> Bonus_Cards { get; set; }
        public DbSet<Bonus_Card_Report> Bonus_Card_Reports { get; set; }
        public DbSet<Discount_Card> Discount_Cards { get; set; }
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

        public MarketDbContext(DbContextOptions<MarketDbContext> options) :base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
