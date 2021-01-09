using System;
using GNDSoft.Students.Infrastructure.Students.Core.DbContexts;
using GNDSoft.Students.Infrastructure.Students.Core.Models.Entities;
using GNDSoft.Students.Infrastructure.Students.Core.Repositories;
using GNDSoft.Students.Infrastructure.Students.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GNDSoft.Students.Infrastructure.Students.Data.Extensions
{
    /// <summary>
    /// Класс с расширениями для регистрации репозиториев по управлению студентами и курсами
    /// </summary>
    public static class RegisterRepositoriesExtension
    {
        /// <summary>
        /// Регистрация сервисов по управлению сущностями
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddStudetnRepositories<TStudentsDbContext, TStudent, TCourse, TStudentCourse, TKey>(this IServiceCollection services)
            where TStudentsDbContext: StudentsDbContext<TStudent, TCourse, TStudentCourse, TKey>
            where TStudent : StudentBase<TKey>
            where TCourse : CourseBase<TKey>
            where TStudentCourse: StudentCourseBase<TKey>
            where TKey : IEquatable<TKey>
        {
            services.AddTransient<IStudentsRepository<TStudent, TCourse, TKey>, 
                StudentsRepository<TStudentsDbContext, TStudent, TCourse, TStudentCourse, TKey>>();

            return services;
        }
    }
}