using System;
using GNDSoft.Students.Infrastructure.Students.Core.DbContexts;
using GNDSoft.Students.Infrastructure.Students.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GNDSoft.Students.Infrastructure.Students.Data.DbContexts
{
    /// <summary>
    /// Констект подключения к БД студентов и курсов
    /// </summary>
    public class StudentsContext: StudentsDbContext<Student, Course, StudentCourse, Guid>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="options">Параметры создания контекста</param>
        /// <returns></returns>
        public StudentsContext(DbContextOptions<StudentsContext> options) : base(options)
        {      }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}