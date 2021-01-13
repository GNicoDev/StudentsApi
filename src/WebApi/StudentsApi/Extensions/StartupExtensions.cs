using System.IO;
using System.Linq;
using AutoMapper.Configuration;
using GNDSoft.Students.Services.StudentsApi.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace GNDSoft.Students.Services.StudentsApi.Extensions
{
    /// <summary>
    /// Методы расширения для класса Startup
    /// </summary>
    public static class StartupExtensions
    {
        /// <summary>
        /// Регистрация сваггера
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <param name="apiConfiguration"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services,
            IConfiguration configuration, ApiConfiguration apiConfiguration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(apiConfiguration.ApiVersion, new OpenApiInfo { Title = apiConfiguration.ApiName, Version = apiConfiguration.ApiVersion });                
            })
            .ConfigureSwaggerGen(options =>
            {
                options.CustomSchemaIds(x => x.FullName);
                var basePath = Directory.GetCurrentDirectory();
                var xmlFileName = typeof(Startup).Namespace
                    .Split('.').ToList().Last();
                var xmlPath = Path.Combine(basePath, $"{xmlFileName}.xml");
                options.IncludeXmlComments(xmlPath);
            }); ;

            return services;
        }
    }
}