using System;
using System.ComponentModel.DataAnnotations;
using GNDSoft.Students.Infrastructure.Students.Core.Models.Common;

namespace GNDSoft.Students.Infrastructure.Students.Core.Models.Entities
{
    /// <summary>
    /// Базовая модель БД описывающая сущность студента
    /// </summary>
    /// <typeparam name="TKey">Тип уникального идентификатора</typeparam>
    public class StudentBase<TKey>
        where TKey: IEquatable<TKey>
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public TKey Id{get;set;}
        /// <summary>
        /// Имя студента
        /// </summary>
        [Required]
        [StringLength(40)]
        public string FirstName { get; set; }
        /// <summary>
        /// Отчество студента
        /// </summary>
        [StringLength(60)]
        public string MiddleName { get; set; }
        /// <summary>
        /// Фамилия студента
        /// </summary>
        [Required]
        [StringLength(40)]
        public string LastName { get; set; }
        /// <summary>
        /// Пол студента
        /// </summary>
        public GenderEnum Gender { get; set; }
        /// <summary>
        /// Прозвище студента
        /// </summary>
        [StringLength(16, MinimumLength = 6)]
        public string Alias { get; set; }
    }
}