using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GNDSoft.Students.Infrastructure.Students.Core.Models.Entities;

namespace GNDSoft.Students.Infrastructure.Students.Core.Repositories
{
    /// <summary>
    /// Репозиторий по управлению сущностями студентов
    /// </summary>
    public interface IStudentsRepository<TStudent, TCourse, TKey> : IBaseRepository<TStudent, TKey>
        where TStudent : StudentBase<TKey>
        where TCourse : CourseBase<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Получить список студентов
        /// </summary>
        /// <returns></returns>
        Task<List<TStudent>> GetAllAsync();

        /// <summary>
        /// Получить список студентов вместе с курсами
        /// </summary>
        /// <returns></returns>
        Task<List<TStudent>> GetAllExtendedAsync();

        /// <summary>
        /// Получить информацию об студенте по id
        /// </summary>
        /// <param name="id">Уникальный идентификатор записи</param>
        /// <returns>Инфомарция о записи</returns>
        Task<TStudent> GetOneByIdAsync(TKey id);

        /// <summary>
        /// Получить информацию об студенте по id вместе с курсами
        /// </summary>
        /// <param name="id">Уникальный идентификатор записи</param>
        /// <returns>Инфомарция о записи</returns>
        Task<TStudent> GetOneByIdExtendedAsync(TKey id);
    }
}