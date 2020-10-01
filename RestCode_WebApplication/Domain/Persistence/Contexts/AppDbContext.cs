using Microsoft.EntityFrameworkCore;
using RestCode_WebApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySQL("server=localhost;database=supermarket;user=root;password=password");
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Category Entity
            builder.Entity<Category>().ToTable("Categories");

            // Constraints
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>()
                .HasMany(p => p.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);


            builder.Entity<Category>().HasData
                (
                    new Category { Id = 100, Name = "Comida Criolla", RestaurantId = 300 },
                    new Category { Id = 101, Name = "Comida Marina", RestaurantId = 301 }
                );

            // Product Entity
            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.Quantity).IsRequired().HasMaxLength(3);

            builder.Entity<Product>().HasData
                (
                    new Product
                    { Id = 200, Name = "Arroz con Pollo", Quantity = 34, CategoryId = 100 },
                    new Product
                    { Id = 201, Name = "Ceviche", Quantity = 2, CategoryId = 101 }
                );


            //Restaurant Entity
            builder.Entity<Restaurant>().ToTable("Restaurants");
            builder.Entity<Restaurant>().HasKey(p => p.Id);
            builder.Entity<Restaurant>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Restaurant>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Entity<Restaurant>().Property(p => p.Address).IsRequired().HasMaxLength(100);
            builder.Entity<Restaurant>().Property(p => p.CellPhoneNumer).IsRequired().HasMaxLength(9);
            builder.Entity<Restaurant>().Property(p => p.Ruc).IsRequired().HasMaxLength(11);

            builder.Entity<Restaurant>()
                .HasMany(p => p.Categories)
                .WithOne(p => p.Restaurant)
                .HasForeignKey(p => p.RestaurantId);


            builder.Entity<Restaurant>().HasData
                (
                    new Restaurant
                    { Id = 300, Name = "Pepito", Address = "Av. El Sol 345", CellPhoneNumer = 976823467, Ruc = 12342313769 },
                    new Restaurant
                    { Id = 301, Name = "McGrill", Address = "Av. Cutervo 231", CellPhoneNumer = 988746726, Ruc = 12156234229 }
                );
        }

    }
}
