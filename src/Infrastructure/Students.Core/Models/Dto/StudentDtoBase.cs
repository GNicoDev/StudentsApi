using System;
using GNDSoft.Students.Infrastructure.Students.Core.Models.Common;

namespace GNDSoft.Students.Infrastructure.Students.Core.Models.Dto
{
    /// <summary>
    /// Базовая транспортная модель для студента
    /// </summary>
    /// <typeparam name="TKey">Тип уникального идентификатора</typeparam>
    public class StudentDtoBase<TKey>
        where TKey: IEquatable<TKey>
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public TKey Id{get;set;}
        /// <summary>
        /// Имя студента
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Отчество студента
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Фамилия студента
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Пол студента
        /// </summary>
        public SexEnum Sex { get; set; }
        /// <summary>
        /// Прозвище студента
        /// </summary>
        public string Alias { get; set; }
    }
}