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
        public DbSet<WaterPart> WatersParts { get; set; }
        public DbSet<ElectricPart> ElectricsParts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Maggazine> Maggazines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=EverythingForHomeDB;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ElectricPart>().Property(e => e.Price).HasPrecision(18, 2);
            modelBuilder.Entity<WaterPart>().Property(e => e.Price).HasPrecision(18, 2);
            modelBuilder.Entity<Order>().Property(e => e.TotalPrice).HasPrecision(18, 2);
        }


    }
}
