using System;
using GNDSoft.Students.Infrastructure.Students.Core.Models.Common;
using GNDSoft.Students.Infrastructure.Students.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GNDSoft.Students.Infrastructure.Students.Core.ModelConfigurations
{
    /// <summary>
    /// Конфигурация таблицы Students
    /// </summary>
    /// <typeparam name="TKey">Тип уникального идентификатора</typeparam>
    public class StudentConfiguration<TKey> : IEntityTypeConfiguration<StudentBase<TKey>>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Метод конфигурации
        /// </summary>
        /// <param name="builder">Объект настроек</param>
        public void Configure(EntityTypeBuilder<StudentBase<TKey>> builder)
        {
            builder
                .HasKey(s => s.Id);

            builder
                .Property(s => s.Sex)
                .HasConversion(
                    v => v.ToString(),
                    v => (SexEnum)Enum.Parse(typeof(SexEnum), v))
                .IsRequired();

            builder.HasIndex(u => u.Alias)
                .IsUnique();
        }
    }
}