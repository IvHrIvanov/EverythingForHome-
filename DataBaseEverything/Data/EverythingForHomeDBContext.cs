﻿using DataBaseevEverythingForHome.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataBaseevEverythingForHome.Database
{
    public class EverythingForHomeDBContext : IdentityDbContext<Account>
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
            
            modelBuilder.Entity<Product>().Property(e => e.Price).HasPrecision(18, 2);
            base.OnModelCreating(modelBuilder);

        }


    }
}
