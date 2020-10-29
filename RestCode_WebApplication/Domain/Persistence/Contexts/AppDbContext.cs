

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
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Consultancy> Consultancies { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySQL("server=localhost;database=supermarket;user=root;password=password");
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            

            //--------------------------------------------------------------------------------------------------
            //Appointment Entity
            builder.Entity<Appointment>().ToTable("Appointments");
            builder.Entity<Appointment>().HasKey(p => p.Id);
            builder.Entity<Appointment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Appointment>().Property(p => p.CurrentDateTime).IsRequired();
            builder.Entity<Appointment>().Property(p => p.ScheduleDateTime).IsRequired();
            builder.Entity<Appointment>().Property(p => p.Topic).IsRequired().HasMaxLength(20);
            builder.Entity<Appointment>().Property(p => p.MeetLink).IsRequired();


            //Relationships

            //Many to One with Consultant
            //Already in Consultant Relationship

            //Many to One with Owner
            //Already in Owner Relationship

            //One to One with Consultancy
            
            //---------------------------------RECIEN COMENTADO--------------------------------
            
            //builder.Entity<Appointment>().HasOne(p => p.Consultancy)
            //    .WithOne(p => p.Appointment).HasForeignKey<Consultancy>(p => p.AppointmentId);

            //---------------------------------------------------------------------------------

            /*builder.Entity<Request>().HasData
                (
                    new Request { Id = 100, DateSend = Convert.ToDateTime("2020-10-10"), State = true }
                );*/

            //Assignment Entity
            builder.Entity<Assignment>().ToTable("Assignments");
            builder.Entity<Assignment>().HasKey(p => p.Id);
            builder.Entity<Assignment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Assignment>().Property(p => p.State).IsRequired();

            //Relationships

            //Many to One with Restaurant
            //Already in Restaurant Relationship

            //Many to One with Consultant
            //Already in Restaurant Relationship


            //Consultancy Entity
            builder.Entity<Consultancy>().ToTable("Consultancies");
            builder.Entity<Consultancy>().HasKey(p => p.Id);
            builder.Entity<Consultancy>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Consultancy>().Property(p => p.Diagnosis).IsRequired().HasMaxLength(30);
            builder.Entity<Consultancy>().Property(p => p.Recommendation).IsRequired().HasMaxLength(30);

            //Relationships

            //One to One with Appointment
            //Already in Appointment Relationship

            //Apply Naming Conventions Policy
            builder.ApplySnakeCaseNamingConvention();
            
        }

    }
}
