using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GNDSoft.Students.Infrastructure.Students.Core.Models.Entities;

namespace GNDSoft.Students.Infrastructure.Students.Core.Repositories
{
    /// <summary>
    /// Репозиторий по управлению сущностями курсов
    /// </summary>
    public interface ICoursesRepository<TStudent, TCourse, TKey>: IBaseRepository<TCourse, TKey>
        where TStudent : StudentBase<TKey>
        where TCourse : CourseBase<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Получить список курсов
        /// </summary>
        /// <returns></returns>
        Task<List<TCourse>> GetAllAsync();

        /// <summary>
        /// Получить список курсов вместе со студентами
        /// </summary>
        /// <returns></returns>
        Task<List<TCourse>> GetAllExtendedAsync();

        /// <summary>
        /// Получить информацию о курсе по id
        /// </summary>
        /// <param name="id">Уникальный идентификатор записи</param>
        /// <returns>Инфомарция о записи</returns>
        Task<TCourse> GetOneByIdAsync(TKey id);

        /// <summary>
        /// Получить информацию о курсе по id вместе с студентами
        /// </summary>
        /// <param name="id">Уникальный идентификатор записи</param>
        /// <returns>Инфомарция о записи</returns>
        Task<TCourse> GetOneByIdExtendedAsync(TKey id);
    }
}