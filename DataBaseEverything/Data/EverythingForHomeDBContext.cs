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
        public DbSet<Product> Products { get; set; }
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
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().Property(e => e.Price).HasPrecision(18, 2);
           
        }


    }
}
