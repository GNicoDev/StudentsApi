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
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Обновить данные в записи
        /// </summary>
        /// <param name="entity">Данные новой записи</param>
        /// <returns>Обвленная запись</returns>
        Task<TEntity> UpdateAsync(TEntity entity);
        
        /// <summary>
        /// Асинхронное удаление записи из таблицы
        /// </summary>
        /// <param name="entry">Объект для удаления</param>
        /// <returns>Статус операции</returns>
        Task<bool> DeleteAsync(TEntity entry);

        /// <summary>
        /// Асихнронное сохранение изменений
        /// </summary>
        /// <returns>Статус операции</returns>
        Task<bool> CommitAsync();
    }
}