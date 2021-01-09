using System;

namespace GNDSoft.Students.Infrastructure.Students.Core.Models.Dto
{
    /// <summary>
    /// Базовая транспортная модель для курса
    /// </summary>
    /// <typeparam name="TKey">Тип уникального идентификатора</typeparam>
    public class CourseDtoBase<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public TKey Id { get; set; }
        /// <summary>
        /// Название курса
        /// </summary>
        public string Name { get; set; }
    }
}