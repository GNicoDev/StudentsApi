using System;
using GNDSoft.Students.Infrastructure.Students.Core.ModelConfigurations;
using GNDSoft.Students.Infrastructure.Students.Core.Models.Entityes;
using Microsoft.EntityFrameworkCore;

namespace GNDSoft.Students.Infrastructure.Students.Core.DbContexts
{
    /// <summary>
    /// Базовый контекст БД по управлению сущностями студентов
    /// </summary>
    /// <typeparam name="TStudent">Сущность студента</typeparam>
    /// <typeparam name="TCourse">Сущность курса</typeparam>
    /// <typeparam name="TStudentCourse">Сущность связи студента и курса</typeparam>
    /// <typeparam name="TKey">Тип уникального идентификатора</typeparam>
    public class StudentsDbContext<TStudent, TCourse, TStudentCourse, TKey> : DbContext
        where TStudent : StudentBase<TKey>
        where TCourse : CourseBase<TKey>
        where TStudentCourse : StudentCourseBase<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Конструтор
        /// </summary>
        /// <param name="options">Опции контекста БД</param>
        public StudentsDbContext(DbContextOptions options) : base(options)
        {     }

        /// <summary>
        /// Таблица студентов
        /// </summary>
        public DbSet<TStudent> Students { get; set; }
        /// <summary>
        /// Таблица курсов
        /// </summary>
        public DbSet<TCourse> Cources { get; set; }
        /// <summary>
        /// Таблица связи курсы студенты
        /// </summary>
        public DbSet<TStudentCourse> StudentCources { get; set; }

        /// <summary>
        /// Метод по конфигурации таблиц
        /// </summary>
        /// <param name="modelBuilder">Объект билдера моделей</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new StudentConfiguration<TKey>())
                .ApplyConfiguration(new CourseConfiguration<TKey>());
        }
    }
}