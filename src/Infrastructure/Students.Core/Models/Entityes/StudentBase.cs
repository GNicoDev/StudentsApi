using System;
using System.ComponentModel.DataAnnotations;
using GNDSoft.Students.Infrastructure.Students.Core.Models.Common;

namespace GNDSoft.Students.Infrastructure.Students.Core.Models.Entityes
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
        public string FirstName { get; set; }
        /// <summary>
        /// Отчество студента
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Фамилия студента
        /// </summary>
        [Required]
        public string LastName { get; set; }
        /// <summary>
        /// Пол студента
        /// </summary>
        /// <value></value>
        public SexEnum Sex { get; set; }
        /// <summary>
        /// Прозвище студента
        /// </summary>
        public string Alias { get; set; }
        
    }
}