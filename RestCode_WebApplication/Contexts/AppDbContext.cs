using Microsoft.EntityFrameworkCore;
using RestCode_WebApplication.Domain.Models;

namespace RestCode_WebApplication.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Owner> Owners { get; set; }
        public DbSet<DailySale> DailySales { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Owner Entity

            builder.Entity<Owner>().ToTable("Duenios");
            builder.Entity<Owner>().HasKey(p => p.Id);
            builder.Entity<Owner>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Owner>().Property(p => p.ConnectedTime)
                .IsRequired();

            // Datos base owners
            builder.Entity<Owner>().HasData
                (
                    new Owner { Id = 100, ConnectedTime = 1024 },
                    new Owner { Id = 101, ConnectedTime = 231 },
                    new Owner { Id = 102, ConnectedTime = 768 },
                    new Owner { Id = 103, ConnectedTime = 987 },
                    new Owner { Id = 104, ConnectedTime = 123 }
                );
            // DailySale entity
            builder.Entity<DailySale>().ToTable("Ingresos");
            builder.Entity<DailySale>().HasKey(p => p.Id);
            builder.Entity<DailySale>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<DailySale>().Property(p => p.QuantityDailySales)
                .IsRequired();
            builder.Entity<DailySale>().Property(p => p.Incomes)
                .IsRequired();
            builder.Entity<DailySale>().Property(p => p.Expenses)
                .IsRequired();
            builder.Entity<DailySale>().Property(p => p.TypeMenuDay)
                .IsRequired();

            // Datos base DailySales
            builder.Entity<DailySale>().HasData
                (
                    new DailySale
                    {
                        Id = 100,
                        QuantityDailySales = 200,
                        Incomes = 300,
                        Expenses = 100,
                        TypeMenuDay = "Pasta"
                    },
                    new DailySale
                    {
                        Id = 101,
                        QuantityDailySales = 200,
                        Incomes = 400,
                        Expenses = 200,
                        TypeMenuDay = "Estofado"
                    }
                );
        }
    }
}
