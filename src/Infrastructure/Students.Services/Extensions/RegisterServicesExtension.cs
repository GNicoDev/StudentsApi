using System;
using GNDSoft.Students.Infrastructure.Students.Core.Models.Dto;
using GNDSoft.Students.Infrastructure.Students.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GNDSoft.Students.Infrastructure.Students.Services.Extensions
{
    /// <summary>
    /// Класс с расширениями для регистрации сервисов по управлению студентами и курсами
    /// </summary>
    public static class RegisterServicesExtension
    {
        /// <summary>
        /// Регистрация сервисов по управлению сущностями
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddStudetnServices<TStudentDto, TCourseDto, TKey>(this IServiceCollection services)
            where TStudentDto : StudentDtoBase<TKey>
            where TCourseDto : CourseDtoBase<TKey>
            where TKey : IEquatable<TKey>
        {
            services.AddTransient<IStudentsService<TStudentDto, TCourseDto, TKey>, StudentsService<TStudentDto, TCourseDto, TKey>>();

            return services;
        }
    }
}