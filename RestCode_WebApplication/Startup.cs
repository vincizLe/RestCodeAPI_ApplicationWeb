using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RestCode_WebApplication.Domain.Persistence.Contexts;
using RestCode_WebApplication.Domain.Repositories;
using RestCode_WebApplication.Domain.Services;
using RestCode_WebApplication.Extensions;
using RestCode_WebApplication.Persistence.Repositories;
using RestCode_WebApplication.Services;

namespace RestCode_WebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<AppDbContext>(options =>
            {
                //options.UseInMemoryDatabase("supermarket-api-in-memory");
                //options.UseMySQL("server=localhost;database=supermarket;user=root;password=password");
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IConsultancyRepository, ConsultancyRepository>();
            services.AddScoped<IAssignmentRepository, AssignmentRepository>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();

           
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IConsultancyService, ConsultancyService>();
            services.AddScoped<IAssignmentService, AssignmentService>();

            //services.AddSwaggerGen(c => {
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RestCode API", Version = "v1" });
            //});

            services.AddAutoMapper(typeof(Startup));

            //services.AddRouting(options => options.LowercaseUrls = true);
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddCustomSwagger();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseSwagger();
            //
            //app.UseSwaggerUI(c => {
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestCode API V1");
            //});
            app.UseCustomeSwagger();
        }
    }
}
