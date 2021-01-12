using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GNDSoft.Students.Infrastructure.Students.Core.DbContexts;
using GNDSoft.Students.Infrastructure.Students.Core.Models.Entities;
using GNDSoft.Students.Infrastructure.Students.Core.Repositories;
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
            ILogger<CoursesRepository<TStudentsDbContext, TStudent, TCourse, TStudentCourse, TKey>> logger = null): base(dbContext)
        {
            _studentsContext = dbContext;
            _logger = logger ?? NullLogger<CoursesRepository<TStudentsDbContext, TStudent, TCourse, TStudentCourse, TKey>>.Instance;
        }


    }
}