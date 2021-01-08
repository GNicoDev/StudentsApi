using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GNDSoft.Students.Infrastructure.Students.Core.Repositories
{
    /// <summary>
    /// Базовый обобщенный интерфейс по управлению сущностями
    /// </summary>
    /// <typeparam name="TEntity">Объект БД</typeparam>
    /// <typeparam name="TKey">Уникальный идентификатор сущности</typeparam>
    public interface IBaseRepository<TEntity, TKey>
        where TEntity: class
        where TKey:IEquatable<TKey>
    {
        /// <summary>
        /// Асинхронное добавление записи в таблицу
        /// </summary>
        /// <param name="entity">Новая запись</param>
        /// <returns>Информация о добавленной записи</returns>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// Получение списка всех записей в БД
        /// </summary>
        /// <returns>Список записей</returns>
        Task<List<TEntity>> GetAllAsync();

        /// <summary>
        /// Получить информацию об одной записи по id
        /// </summary>
        /// <param name="id">Уникальный идентификатор записи</param>
        /// <returns>Инфомарция о записи</returns>
        Task<TEntity> GetOneAsync(TKey id);

        /// <summary>
        /// Обновить данные в записи
        /// </summary>
        /// <param name="entity">Данные новой записи</param>
        /// <returns>Обвленная запись</returns>
        Task<TEntity> UpdateAsync(TEntity entity);
        
        /// <summary>
        /// Асинхронное удаление записи из таблицы
        /// </summary>
        /// <param name="entry">Уникальный идентификатор записи</param>
        /// <returns>Статус операции</returns>
        Task<bool> DeleteAsync(TEntity entry);
    }
}