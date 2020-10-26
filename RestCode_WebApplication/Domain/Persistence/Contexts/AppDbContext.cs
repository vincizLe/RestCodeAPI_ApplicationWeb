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


            // Restaurant Entity
            builder.Entity<Restaurant>().ToTable("Restaurants");
            builder.Entity<Restaurant>().HasKey(p => p.Id);
            builder.Entity<Restaurant>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Restaurant>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Entity<Restaurant>().Property(p => p.Address).IsRequired().HasMaxLength(100);
            builder.Entity<Restaurant>().Property(p => p.CellphoneNumber).HasMaxLength(9);
            builder.Entity<Restaurant>().Property(p => p.Ruc).IsRequired().HasMaxLength(11);

            builder.Entity<Restaurant>()
                .HasMany(p => p.Categories)
                .WithOne(p => p.Restaurant)
                .HasForeignKey(p => p.RestaurantId);

            builder.Entity<Restaurant>()
                .HasMany(p => p.Sales)
                .WithOne(p => p.Restaurant)
                .HasForeignKey(p => p.RestaurantId);


            builder.Entity<Restaurant>().HasData
                (
                    new Restaurant
                    { Id = 300, Name = "Pepito", Address = "Av. El Sol 345", CellphoneNumber = 976823467, Ruc = 12342313769 },
                    new Restaurant
                    { Id = 301, Name = "McGrill", Address = "Av. Cutervo 231", CellphoneNumber = 988746726, Ruc = 12156234229 }
                );
            // Sales entity
            builder.Entity<Sale>().ToTable("Sales");
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
            builder.Entity<SaleDetail>().HasKey(p => p.Id);
            builder.Entity<SaleDetail>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<SaleDetail>().Property(p => p.Description).IsRequired().HasMaxLength(300);
            builder.Entity<SaleDetail>().Property(p => p.Quantity).IsRequired().HasMaxLength(100);

            builder.Entity<SaleDetail>().HasData
                (
                    new SaleDetail
                    { Id = 100, Description = "Description SD1", Quantity = 100, SaleId = 150 },
                    new SaleDetail
                    { Id = 100, Description = "Description SD2", Quantity = 200, SaleId = 151 }

                );
            // Owners Entity
            builder.Entity<Owner>().ToTable("Owners");
            builder.Entity<Owner>().HasKey(p => p.Id);
            builder.Entity<Owner>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Owner>().Property(p => p.RUC).IsRequired().HasMaxLength(100);

            builder.Entity<Owner>().HasData
                  (
                      new Owner
                      { Id = 100, RUC = 202010213 },
                      new Owner
                      { Id = 100, RUC = 202011212 }

                  );
        }

    }
}
