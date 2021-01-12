using System;
using GNDSoft.Students.Infrastructure.Students.Core.Models.Entities;

namespace GNDSoft.Students.Infrastructure.Students.Core.Repositories
{
    /// <summary>
    /// Репозиторий по управлению сущностями курсов
    /// </summary>
    public interface ICoursesRepository<TStudent, TCourses, TKey>: IBaseRepository<TCourses, TKey>
        where TStudent : StudentBase<TKey>
        where TCourses : CourseBase<TKey>
        where TKey : IEquatable<TKey>
    {

    }
}