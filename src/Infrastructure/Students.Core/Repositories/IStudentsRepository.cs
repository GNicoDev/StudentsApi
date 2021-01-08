using System;
using GNDSoft.Students.Infrastructure.Students.Core.Models.Entityes;

namespace GNDSoft.Students.Infrastructure.Students.Core.Repositories
{
    /// <summary>
    /// Репозиторий по управлению сущностями студентов
    /// </summary>
    public interface IStudentsRepository<TStudent, TCourse, TKey>
        where TStudent: StudentBase<TKey>
        where TCourse: CourseBase<TKey>
        where TKey: IEquatable<TKey>
    {
        
    }
}