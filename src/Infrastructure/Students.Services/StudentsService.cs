using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GNDSoft.Students.Infrastructure.Students.Core.Models.Dto;
using GNDSoft.Students.Infrastructure.Students.Core.Services;

namespace GNDSoft.Students.Infrastructure.Students.Services
{
    /// <summary>
    /// Сервис по управлению студентами
    /// </summary>
    /// <typeparam name="TStudentDto">Транспортная модель студента</typeparam>
    /// <typeparam name="TCourseDto">Транспортная модель курса</typeparam>
    /// <typeparam name="TKey">Тип уникального идентификатора</typeparam>
    public class StudentsService<TStudentDto, TCourseDto, TKey> : IStudentsService<TStudentDto, TCourseDto, TKey>
        where TStudentDto : StudentDtoBase<TKey>
        where TCourseDto : CourseDtoBase<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <inheritdoc />
        public Task<TStudentDto> AddAsync(TStudentDto dtoModel)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<bool> DeleteAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<List<TStudentDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<TStudentDto> GetOneAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<TStudentDto> UpdateAsync(TStudentDto dtoModel)
        {
            throw new NotImplementedException();
        }
    }
}