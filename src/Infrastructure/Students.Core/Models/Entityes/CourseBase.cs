using System;
using System.ComponentModel.DataAnnotations;

namespace GNDSoft.Students.Infrastructure.Students.Core.Models.Entityes
{
    /// <summary>
    /// Базовая модель БД описывающая сущность курсов для студентов
    /// </summary>
    /// <typeparam name="TKey">Тип уникального идентификатора</typeparam>
    public class CourseBase<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        [Key]
        public TKey Id { get; set; }
        /// <summary>
        /// Название курса
        /// </summary>
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
    }
}