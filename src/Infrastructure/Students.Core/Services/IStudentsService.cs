using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GNDSoft.Students.Infrastructure.Students.Core.Models.Dto;

namespace GNDSoft.Students.Infrastructure.Students.Core.Services
{
    /// <summary>
    /// Интерфейс сервиса по упралению репозиторием Students
    /// </summary>
    /// <typeparam name="TStudentDto">Транспортная модель студента</typeparam>
    /// <typeparam name="TCourseDto">Транспортная модель курса</typeparam>
    /// <typeparam name="TKey">Тип уникального идентификатора</typeparam>
    public interface IStudentsService<TStudentDto, TCourseDto, TKey>
        where TStudentDto: StudentDtoBase<TKey>
        where TCourseDto: CourseDtoBase<TKey>
        where TKey: IEquatable<TKey>
    {
        /// <summary>
        /// Асинхронное добавление записи
        /// </summary>
        /// <param name="dtoModel">Новая запись</param>
        /// <returns>Информация о добавленной записи</returns>
        Task<TStudentDto> AddAsync(TStudentDto dtoModel);

        /// <summary>
        /// Получение списка всех записей
        /// </summary>
        /// <returns>Список записей</returns>
        List<TStudentDto> GetAll();

        /// <summary>
        /// Получение списка всех записей
        /// </summary>
        /// <returns>Список записей</returns>
        Task<List<TStudentDto>> GetAllAsync();

        /// <summary>
        /// Получить информацию об одной записи по id
        /// </summary>
        /// <param name="id">Уникальный идентификатор записи</param>
        /// <returns>Инфомарция о записи</returns>
        Task<TStudentDto> GetOneAsync(TKey id);

        /// <summary>
        /// Получить информацию об одной записи по id
        /// </summary>
        /// <param name="id">Уникальный идентификатор записи</param>
        /// <returns>Инфомарция о записи</returns>
        Task<TStudentDto> GetOneExtendedAsync(TKey id);

        /// <summary>
        /// Обновить данные в записи
        /// </summary>
        /// <param name="dtoModel">Данные новой записи</param>
        /// <returns>Обвленная запись</returns>
        Task<TStudentDto> UpdateAsync(TStudentDto dtoModel);
        
        /// <summary>
        /// Асинхронное удаление записи
        /// </summary>
        /// <param name="id">Уникальный идентификатор записи</param>
        /// <returns>Статус операции</returns>
        Task<bool> DeleteAsync(TKey id);
    }
}