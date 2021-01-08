using System;

namespace GNDSoft.Students.Infrastructure.Students.Core.Models.Entityes
{
    /// <summary>
    /// Базовая модель БД описывающая связь сущностей студентов и их курсов
    /// </summary>
    /// <typeparam name="TKey">Тип уникального идентификатора</typeparam>
    public class StudentCourseBase<TKey>
        where TKey: IEquatable<TKey>
    {
        /// <summary>
        /// Уникальный идентификатор студента
        /// </summary>
        public TKey StudentId { get; set; }

        /// <summary>
        /// Уникальный идентификатор курса
        /// </summary>
        public TKey CourseId { get; set; }
    }
}