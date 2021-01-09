using System;
using GNDSoft.Students.Infrastructure.Students.Core.Models.Dto;

namespace GNDSoft.Students.Infrastructure.Students.Core.Services
{
    /// <summary>
    /// Интерфейс сервиса по упралению репозиторием Students
    /// </summary>
    /// <typeparam name="TStudentDto">Транспортная модель студента</typeparam>
    /// <typeparam name="TCourseDto">Транспортная модель курса</typeparam>
    /// <typeparam name="TKey">Тип уникального идентификатора</typeparam>
    public interface IStudentsService<TStudentDto, TCourseDto, TKey>: IBaseService<TStudentDto, TKey>
        where TStudentDto: StudentDtoBase<TKey>
        where TCourseDto: CourseDtoBase<TKey>
        where TKey: IEquatable<TKey>
    {
        
    }
}