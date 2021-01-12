
using System;
using GNDSoft.Students.Infrastructure.Students.Core.Models.Dto;
using GNDSoft.Students.Infrastructure.Students.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace GNDSoft.Students.Services.StudentsApi.Controllers
{
    /// <summary>
    /// Контроллер для управления студентами
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController<TStudentDto, TCourseDto, TKey>: ControllerBase
        where TStudentDto: StudentDtoBase<TKey>
        where TCourseDto: CourseDtoBase<TKey>
        where TKey: IEquatable<TKey>
    {
        private readonly IStudentsService<TStudentDto, TCourseDto, TKey> _studentsService;
        private readonly ILogger<StudentsController<TStudentDto, TCourseDto, TKey>> _logger;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="logger"></param>
        public StudentsController(ILogger<StudentsController<TStudentDto, TCourseDto, TKey>> logger = null)
        {
            _logger = logger ?? NullLogger<StudentsController<TStudentDto, TCourseDto, TKey>>.Instance;
        }

        
    }
}