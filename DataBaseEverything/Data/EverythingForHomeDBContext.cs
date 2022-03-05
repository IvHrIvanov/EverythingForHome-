using DataBaseevEverythingForHome.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseevEverythingForHome.Database
{
    public class EverythingForHomeDBContext : DbContext
    {
        public EverythingForHomeDBContext()
        {

        }
        public EverythingForHomeDBContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Shop> Shops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=EverythingForHomeDB;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().Property(e => e.Price).HasPrecision(18, 2);
            modelBuilder.Entity<Order>().Property(e => e.TotalPrice).HasPrecision(18, 2);
        }


    }
}
