using System;
using GNDSoft.Students.Infrastructure.Students.Core.Models.Entities;

namespace GNDSoft.Students.Infrastructure.Students.Core.Repositories
{
    /// <summary>
    /// Репозиторий по управлению сущностями студентов
    /// </summary>
    public interface IStudentsRepository<TStudent, TCourse, TKey>: IBaseRepository<TStudent, TKey>
        where TStudent: StudentBase<TKey>
        where TCourse: CourseBase<TKey>
        where TKey: IEquatable<TKey>
    {
        
    }
}