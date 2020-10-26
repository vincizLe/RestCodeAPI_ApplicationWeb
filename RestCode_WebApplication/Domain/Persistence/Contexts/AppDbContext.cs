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
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Publication>().ToTable("Publications");
            builder.Entity<Publication>().HasKey(p => p.Id);
            builder.Entity<Publication>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Publication>().Property(p => p.PublishedDate).IsRequired();
            builder.Entity<Publication>().Property(p => p.Description).IsRequired().HasMaxLength(1000);
            builder.Entity<Publication>().HasMany(p => p.Comments).WithOne(p => p.Publication).HasForeignKey(p => p.PublicationId);

            builder.Entity<Publication>().HasData
                (
                    new Publication { Id = 100, 
                        PublishedDate = DateTime.Parse("2020/01/03"), 
                        Description = "Mi nombre es Ana Lopez. Soy una consultora con 10 años de experiencia en el mercado." },
                    new Publication { Id = 101, 
                        PublishedDate = DateTime.Parse("2019/12/11"), 
                        Description = "Mi nombre es Luis Mamani. He trabajado por varios años como consultor de negocios en empresas reconocidas." }
                );

            builder.Entity<Comment>().ToTable("Comments");
            builder.Entity<Comment>().HasKey(p => p.Id);
            builder.Entity<Comment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Comment>().Property(p => p.PublishedDate).IsRequired();
            builder.Entity<Comment>().Property(p => p.Description).IsRequired().HasMaxLength(500);

            builder.Entity<Comment>().HasData
                (
                    new Comment { Id = 200, 
                        PublishedDate = DateTime.Parse("2020/01/06"), 
                        Description = "La consultora Ana es muy confiable.", 
                        PublicationId = 100 },
                    new Comment { Id = 201, 
                        PublishedDate = DateTime.Parse("2019/12/20"), 
                        Description = "Las soluciones que planteó el consultor Luis para mi negocio fueron las mejores", 
                        PublicationId = 101 }
                );

            builder.ApplySnakeCaseNamingConvention();
        }
    }
}