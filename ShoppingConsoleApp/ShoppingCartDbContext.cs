﻿using Microsoft.EntityFrameworkCore;


namespace Shopping.Infrastructure
{
    public class ShoppingCartDbContext : DbContext
    {
        private readonly string _connectionString;
        public DbSet<ShoppingItem> ShoppingItems { get; set; }

        public ShoppingCartDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
       

        public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options) : base(options)
        {
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ShoppingItem>().HasKey(x => x.Id);
            modelBuilder.Entity<ShoppingItem>().Property(x => x.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<ShoppingItem>().Property(x => x.Manufacturer).HasMaxLength(500);
            modelBuilder.Entity<ShoppingItem>().Property(x => x.Price).IsRequired().HasPrecision(18,2);


           
        }
    }
}
