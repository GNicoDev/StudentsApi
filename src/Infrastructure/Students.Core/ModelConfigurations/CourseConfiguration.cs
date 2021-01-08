using System;
using GNDSoft.Students.Infrastructure.Students.Core.Models.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GNDSoft.Students.Infrastructure.Students.Core.ModelConfigurations
{
    /// <summary>
    /// Конфигурация таблицы Cources
    /// </summary>
    /// <typeparam name="TKey">Тип уникального идентификатора</typeparam>
    public class CourseConfiguration<TKey> : IEntityTypeConfiguration<CourseBase<TKey>>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Метод конфигурации
        /// </summary>
        /// <param name="builder">Объект настроек</param>
        public void Configure(EntityTypeBuilder<CourseBase<TKey>> builder)
        {
            builder
                .HasKey(s => s.Id);
        }
    }
}