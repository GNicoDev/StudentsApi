using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GNDSoft.Students.Infrastructure.Students.Core.Models.Entityes;
using GNDSoft.Students.Infrastructure.Students.Core.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace GNDSoft.Students.Infrastructure.Students.Data.Repositories
{
    /// <inheritdoc />
    public class StudentsRepository<TStudent, TCourse, TKey> :
        IStudentsRepository<TStudent, TCourse, TKey>
        where TStudent : StudentBase<TKey>
        where TCourse : CourseBase<TKey>
        where TKey : IEquatable<TKey>
    {
        private readonly ILogger<StudentsRepository<TStudent, TCourse, TKey>> _logger;
        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="logger">Logger</param>
        public StudentsRepository(ILogger<StudentsRepository<TStudent, TCourse, TKey>> logger = null)
        {
            _logger = logger ?? NullLogger<StudentsRepository<TStudent, TCourse, TKey>>.Instance;
        }

        /// <inheritdoc />
        public Task<TStudent> AddAsync(TStudent entity)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<bool> DeleteAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<List<TStudent>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<TStudent> GetOneAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<TStudent> UpdateAsync(TStudent entity)
        {
            throw new NotImplementedException();
        }
    }
}