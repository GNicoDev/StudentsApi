using System;
using GNDSoft.Students.Infrastructure.Students.Data.DbContexts;
using GNDSoft.Students.Infrastructure.Students.Data.Extensions;
using GNDSoft.Students.Infrastructure.Students.Data.Models;
using GNDSoft.Students.Infrastructure.Students.Services.Extensions;
using GNDSoft.Students.Infrastructure.Students.Services.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GNDSoft.Students.Services.StudentsApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddStudetnRepositories<StudentsContext, Student, Course, StudentCourse, Guid>()
                .AddStudetnServices<StudentDto, CourseDto, Guid>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
