using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GNDSoft.Students.Infrastructure.Students.Core.DbContexts;
using GNDSoft.Students.Infrastructure.Students.Core.Models.Entities;
using GNDSoft.Students.Infrastructure.Students.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace GNDSoft.Students.Infrastructure.Students.Data.Repositories
{
    /// <inheritdoc />
    public class StudentsRepository<TStudentsDbContext, TStudent, TCourse, TStudentCourse, TKey> :
        IStudentsRepository<TStudent, TCourse, TKey>
        where TStudentsDbContext: StudentsDbContext<TStudent, TCourse, TStudentCourse, TKey>
        where TStudent : StudentBase<TKey>
        where TCourse : CourseBase<TKey>
        where TStudentCourse: StudentCourseBase<TKey>
        where TKey : IEquatable<TKey>
    {
        private readonly TStudentsDbContext _studentsContext;
        private readonly ILogger<StudentsRepository<TStudentsDbContext, TStudent, TCourse, TStudentCourse, TKey>> _logger;
        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="studentsContext">Контекст БД по управлению сущностями студентов</param>
        /// <param name="logger">Logger</param>
        public StudentsRepository(TStudentsDbContext studentsContext,
            ILogger<StudentsRepository<TStudentsDbContext, TStudent, TCourse, TStudentCourse, TKey>> logger = null)
        {
            _studentsContext = studentsContext;
            _logger = logger ?? NullLogger<StudentsRepository<TStudentsDbContext, TStudent, TCourse, TStudentCourse, TKey>>.Instance;
        }

        /// <inheritdoc />
        public async Task<TStudent> AddAsync(TStudent entity)
        {
            await _studentsContext.Students.AddAsync(entity);
            var res = await _studentsContext.SaveChangesAsync();
            
            return entity;
        }

        /// <inheritdoc />
        public async Task<bool> DeleteAsync(TStudent student)
        {
            _studentsContext.Students.Remove(student);
            var res = await _studentsContext.SaveChangesAsync();

            return res > 0;
        }

        /// <inheritdoc />
        public Task<List<TStudent>> GetAllAsync()
        {
            var allEntries = _studentsContext.Students
                .Join(_studentsContext.Set<TStudentCourse>(), s => s.Id, sc => sc.StudentId, (s, sc) => new {s, sc})
                .Select(t => t.s);

            return allEntries.ToListAsync();
        }

        /// <inheritdoc />
        public Task<TStudent> GetOneAsync(TKey id)
        {
            var entry = _studentsContext
                .Students
                .SingleOrDefaultAsync(it => it.Id.Equals(id));

            return entry;
        }

        /// <inheritdoc />
        public async Task<TStudent> UpdateAsync(TStudent entity)
        {
            _studentsContext.Students.Update(entity);
            var res = await _studentsContext.SaveChangesAsync();

            return entity;
        }
    }
}