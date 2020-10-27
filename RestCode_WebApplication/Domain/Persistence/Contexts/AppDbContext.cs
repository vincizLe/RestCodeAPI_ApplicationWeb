

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
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySQL("server=localhost;database=supermarket;user=root;password=password");
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Restaurant Entity
            builder.Entity<Restaurant>().ToTable("Restaurants");

            // Constraints
            builder.Entity<Restaurant>().HasKey(p => p.Id);
            builder.Entity<Restaurant>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Restaurant>().Property(p => p.RestaurantName).IsRequired().HasMaxLength(100);
            builder.Entity<Restaurant>().Property(p => p.RestaurantAddress).IsRequired().HasMaxLength(100);
            builder.Entity<Restaurant>().Property(p => p.RestaurantCellPhoneNumber).IsRequired().HasMaxLength(9);

            builder.Entity<Restaurant>()
                .HasMany(p => p.Categories)
                .WithOne(p => p.Restaurant)
                .HasForeignKey(p => p.RestaurantId);

            builder.Entity<Restaurant>().HasData
                (
                    new Restaurant
                    { Id = 300, RestaurantName = "Pepito", RestaurantAddress = "Av. El Sol 345", RestaurantCellPhoneNumber = 976823467},
                    new Restaurant
                    { Id = 301, RestaurantName = "McGrill", RestaurantAddress = "Av. Cutervo 231", RestaurantCellPhoneNumber = 988746726}
                );

            // Category Entity
            builder.Entity<Category>().ToTable("Categories");

            // Constraints
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.CategoryName).IsRequired().HasMaxLength(30);
            builder.Entity<Category>()
                .HasMany(p => p.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);


            builder.Entity<Category>().HasData
                (
                    new Category { Id = 100, CategoryName = "Comida Criolla", RestaurantId = 300 },
                    new Category { Id = 101, CategoryName = "Comida Marina", RestaurantId = 301 }
                );

            // Product Entity
            builder.Entity<Product>().ToTable("Products");

            // Constraints
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.ProductName).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.ProductPrice).IsRequired().HasMaxLength(3);

            builder.Entity<Product>().HasData
                (
                    new Product
                    { Id = 200, ProductName = "Arroz con Pollo", ProductPrice = 12.5, CategoryId = 100 },
                    new Product
                    { Id = 201, ProductName = "Ceviche", ProductPrice = 13.0, CategoryId = 101 }
                );

            // Sales entity
            builder.Entity<Sale>().ToTable("Sales");

            // Constraints
            builder.Entity<Sale>().HasKey(p => p.Id);
            builder.Entity<Sale>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Sale>().Property(p => p.DateAndTime).IsRequired();
            builder.Entity<Sale>().Property(p => p.ClientFullName).IsRequired().HasMaxLength(100);

            builder.Entity<Sale>()
                .HasMany(p => p.SaleDetails)
                .WithOne(p => p.Sale)
                .HasForeignKey(p => p.SaleId);

            builder.Entity<Sale>().HasData
               (
                   new Sale
                   { Id = 150, DateAndTime = DateTime.Now.AddDays(4), ClientFullName = "Juan Perez", RestaurantId = 300 },
                   new Sale
                   { Id = 151, DateAndTime = DateTime.Now.AddDays(7), ClientFullName = "Jose Fulano", RestaurantId = 301 }

               );

            // SaleDetails entity
            builder.Entity<SaleDetail>().ToTable("SaleDetails");

            // Constraints
            builder.Entity<SaleDetail>().HasKey(p => p.Id);
            builder.Entity<SaleDetail>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<SaleDetail>().Property(p => p.Description).IsRequired().HasMaxLength(300);
            builder.Entity<SaleDetail>().Property(p => p.Quantity).IsRequired().HasMaxLength(100);

            builder.Entity<SaleDetail>().HasData
                (
                    new SaleDetail
                    { Id = 100, Description = "Description SD1", Quantity = 100, SaleId = 150 },
                    new SaleDetail
                    { Id = 101, Description = "Description SD2", Quantity = 200, SaleId = 151 }

                );

            // Owners Entity
            builder.Entity<Owner>().ToTable("Owners");

            // Constraints
            builder.Entity<Owner>().HasKey(p => p.Id);
            builder.Entity<Owner>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Owner>().Property(p => p.Ruc).IsRequired().HasMaxLength(100);

            builder.Entity<Owner>().HasData
                  (
                      new Owner
                      { Id = 200, Ruc = 202010213 },
                      new Owner
                      { Id = 201, Ruc = 202011212 }

                  );

        }

    }
}
