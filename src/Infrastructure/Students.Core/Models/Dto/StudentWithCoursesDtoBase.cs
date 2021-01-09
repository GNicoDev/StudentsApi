using System;
using System.Collections.Generic;

namespace GNDSoft.Students.Infrastructure.Students.Core.Models.Dto
{
    /// <summary>
    /// Базовая транспортная модель для студента и его курсов
    /// </summary>
    public class StudentWithCoursesDtoBase<TCourseDto, TKey>: StudentDtoBase<TKey>
        where TCourseDto: CourseDtoBase<TKey>
        where TKey:IEquatable<TKey>
    {
        /// <summary>
        /// Список курсов студента
        /// </summary>
        public List<TCourseDto> Courses { get; set; }
    }
}