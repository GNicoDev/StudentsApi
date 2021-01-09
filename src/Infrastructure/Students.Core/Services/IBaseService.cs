using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GNDSoft.Students.Infrastructure.Students.Core.Services
{
    /// <summary>
    /// Базовый интерфейс для сервиса управления репозиторием
    /// </summary>
    public interface IBaseService<TDto, TKey>
        where TDto: class
        where TKey:IEquatable<TKey>
    {
        /// <summary>
        /// Асинхронное добавление записи
        /// </summary>
        /// <param name="dtoModel">Новая запись</param>
        /// <returns>Информация о добавленной записи</returns>
        Task<TDto> AddAsync(TDto dtoModel);

        /// <summary>
        /// Получение списка всех записей
        /// </summary>
        /// <returns>Список записей</returns>
        Task<List<TDto>> GetAllAsync();

        /// <summary>
        /// Получить информацию об одной записи по id
        /// </summary>
        /// <param name="id">Уникальный идентификатор записи</param>
        /// <returns>Инфомарция о записи</returns>
        Task<TDto> GetOneAsync(TKey id);

        /// <summary>
        /// Обновить данные в записи
        /// </summary>
        /// <param name="dtoModel">Данные новой записи</param>
        /// <returns>Обвленная запись</returns>
        Task<TDto> UpdateAsync(TDto dtoModel);
        
        /// <summary>
        /// Асинхронное удаление записи
        /// </summary>
        /// <param name="id">Уникальный идентификатор записи</param>
        /// <returns>Статус операции</returns>
        Task<bool> DeleteAsync(TKey id);
    }
}