using System;
using GNDSoft.Students.Infrastructure.Students.Core.Models.Dto;
using GNDSoft.Students.Infrastructure.Students.Core.Models.Entities;

namespace GNDSoft.Students.Infrastructure.Students.Core.Mappers
{
    /// <summary>
    /// Профиль для маппинга сущностей студентов из Entity в Dto и обратно
    /// </summary>
    public class StudentsMapperProfile<TStudent,
        TStudentDto,
        TKey>
        where TStudent: StudentBase<TKey>
        where TStudentDto: StudentDtoBase<TKey>
        where TKey: IEquatable<TKey>
    {
        
    }
}