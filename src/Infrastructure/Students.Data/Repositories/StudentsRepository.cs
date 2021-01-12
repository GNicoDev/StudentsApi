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
        BaseRepository<TStudentsDbContext, TStudent, TKey>,
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
        /// <param name="dbContext">Контекст БД по управлению сущностями студентов</param>
        /// <param name="logger">Logger</param>
        public StudentsRepository(TStudentsDbContext dbContext,
            ILogger<StudentsRepository<TStudentsDbContext, TStudent, TCourse, TStudentCourse, TKey>> logger = null): base(dbContext)
        {
            _studentsContext = dbContext;
            _logger = logger ?? NullLogger<StudentsRepository<TStudentsDbContext, TStudent, TCourse, TStudentCourse, TKey>>.Instance;
        }

        /// <inheritdoc />
        public Task<List<TStudent>> GetAllAsync()
        {
            var students = this.DbSet;
            return students.ToListAsync();
        }

        /// <inheritdoc />
        public Task<List<TStudent>> GetAllExtendedAsync()
        {
            var allEntries = DbSet
                .Join(_studentsContext.Set<TStudentCourse>(), s => s.Id, sc => sc.StudentId, (s, sc) => new {s, sc})
                .Select(t => t.s);

            return allEntries.ToListAsync();
        }

        /// <inheritdoc />
        public Task<TStudent> GetOneByIdAsync(TKey id)
        {
            var student = DbSet
                .SingleOrDefaultAsync(it => it.Id.Equals(id));

            return student;
        }

        /// <inheritdoc />
        public Task<TStudent> GetOneByIdExtendedAsync(TKey id)
        {
            var student = DbSet
                .Join(_studentsContext.Set<TStudentCourse>(), s => s.Id, sc => sc.StudentId, (s, sc) => new {s, sc})
                .Select(t => t.s)
                .SingleOrDefaultAsync(it => it.Id.Equals(id));

            return student;
        }
    }
}