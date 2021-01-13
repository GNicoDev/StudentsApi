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
    public class CoursesRepository<TStudentsDbContext, TStudent, TCourse, TStudentCourse, TKey> :
        BaseRepository<TStudentsDbContext, TCourse, TKey>,
        ICoursesRepository<TStudent, TCourse, TKey>
        where TStudentsDbContext: StudentsDbContext<TStudent, TCourse, TStudentCourse, TKey>
        where TStudent : StudentBase<TKey>
        where TCourse : CourseBase<TKey>
        where TStudentCourse: StudentCourseBase<TKey>
        where TKey : IEquatable<TKey>
    {
        private readonly TStudentsDbContext _studentsContext;
        private readonly ILogger<CoursesRepository<TStudentsDbContext, TStudent, TCourse, TStudentCourse, TKey>> _logger;
        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">Контекст БД по управлению сущностями студентов</param>
        /// <param name="logger">Logger</param>
        public CoursesRepository(TStudentsDbContext dbContext,
            ILogger<CoursesRepository<TStudentsDbContext, TStudent, TCourse, TStudentCourse, TKey>> logger = null): base(dbContext, logger)
        {
            _studentsContext = dbContext;
            _logger = logger ?? NullLogger<CoursesRepository<TStudentsDbContext, TStudent, TCourse, TStudentCourse, TKey>>.Instance;
        }

        /// <inheritdoc />
        public Task<List<TCourse>> GetAllAsync()
        {
            var courses = this.DbSet;

            _logger.LogDebug("Getting all courses from db");
            return courses.ToListAsync();
        }

        /// <inheritdoc />
        public Task<List<TCourse>> GetAllExtendedAsync()
        {
            var allEntries = DbSet
                .Join(_studentsContext.Set<TStudentCourse>(), c => c.Id, cs => cs.CourseId, (c, cs) => new {c, cs})
                .Select(t => t.c);

            _logger.LogDebug("Getting all courses with students from db");
            return allEntries.ToListAsync();
        }

        /// <inheritdoc />
        public Task<TCourse> GetOneByIdAsync(TKey id)
        {
            var course = DbSet
                .SingleOrDefaultAsync(it => it.Id.Equals(id));

            _logger.LogDebug($"Get course with id {id} from db");
            return course;
        }

        /// <inheritdoc />
        public Task<TCourse> GetOneByIdExtendedAsync(TKey id)
        {
            var course = DbSet
                .Join(_studentsContext.Set<TStudentCourse>(), c => c.Id, cs => cs.CourseId, (c, cs) => new {c, cs})
                .Select(t => t.c)
                .SingleOrDefaultAsync(it => it.Id.Equals(id));

            _logger.LogDebug($"Get course (with students) with id {id} from db");
            return course;
        }
    }
}