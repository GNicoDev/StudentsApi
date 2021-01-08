using System;

namespace GNDSoft.Students.Infrastructure.Students.Core.Models.Entityes
{
    /// <summary>
    /// Базовая модель БД описывающая связь сущностей студентов и их курсов
    /// </summary>
    /// <typeparam name="TStudent">Сущность студента</typeparam>
    /// <typeparam name="TCourse">Сущность курса</typeparam>
    /// <typeparam name="TKey">Тип уникального идентификатора</typeparam>
    public class StudentCourceBase<TStudent, TCourse, TKey>
        where TStudent: StudentBase<TKey>
        where TCourse: CourseBase<TKey>
        where TKey: IEquatable<TKey>
    {
        /// <summary>
        /// Уникальный идентификатор студента
        /// </summary>
        public TKey StudentId { get; set; }
        /// <summary>
        /// Сущность студента
        /// </summary>
        public TStudent Student { get; set; }

        /// <summary>
        /// Уникальный идентификатор курса
        /// </summary>
        public TKey CourseId { get; set; }
        /// <summary>
        /// Сущность курса
        /// </summary>
        /// <value></value>
        public TCourse Course { get; set; }
    }
}