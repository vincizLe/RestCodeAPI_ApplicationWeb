

using Microsoft.EntityFrameworkCore;
using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Extensions;
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
        public DbSet<Consultant> Consultants { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySQL("server=localhost;database=supermarket;user=root;password=password");
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            //Consultant Entity
            builder.Entity<Consultant>().ToTable("Consultants");
            // Constraints
            builder.Entity<Consultant>().HasKey(p => p.Id);
            builder.Entity<Consultant>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Consultant>().Property(p => p.FirstName).IsRequired();
            builder.Entity<Consultant>().Property(p => p.LastName).IsRequired();
            builder.Entity<Consultant>().Property(p => p.Cellphone).IsRequired();
            builder.Entity<Consultant>().Property(p => p.Email).IsRequired();
            builder.Entity<Consultant>().Property(p => p.Password).IsRequired();
            builder.Entity<Consultant>().Property(p => p.Validation).IsRequired();
            builder.Entity<Consultant>().Property(p => p.LinkedinLink).IsRequired();

            builder.Entity<Consultant>().HasData
                (
                new Consultant
                { Id = 20, FirstName = "Abece", LastName = "Deefe", Cellphone = "95681914", Email = "abcdef.letras.com", Password = "password", Validation = true, LinkedinLink = "abcd.com" },
                new Consultant
                { Id = 22, FirstName = "Aeiou", LastName = "Lol", Cellphone = "9456988", Email = "aeiou.vocal.com", Password = "P4sw0rd", Validation = true, LinkedinLink = "aeiou.com" }
                );

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

            //Apply Naming Conventions Policy

            builder.ApplySnakeCaseNamingConvention();
            
        }

    }
}
