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
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Объект конфигурации сервиса
        /// </summary>
        /// <value></value>
        public IConfiguration Configuration { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="configuration">Объект конфигурации сервиса</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Метод конфигурации сервиса
        /// </summary>
        /// <param name="services">Коллекция сервисов</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddStudetnRepositories<StudentsContext, Student, Course, StudentCourse, Guid>()
                .AddStudetnServices<Student, Course, StudentDto, CourseDto, Guid>();
            services.AddControllers();
        }

        /// <summary>
        /// Метод конфигурации конвейера обработки запросов
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env">Интерфейс окружения хоста</param>
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
