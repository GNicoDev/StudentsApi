using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GNDSoft.Students.Infrastructure.Students.Core.Exceptions;
using GNDSoft.Students.Infrastructure.Students.Core.Models.Dto;
using GNDSoft.Students.Infrastructure.Students.Core.Models.Entities;
using GNDSoft.Students.Infrastructure.Students.Core.Repositories;
using GNDSoft.Students.Infrastructure.Students.Core.Services;
using Microsoft.Extensions.Logging;

namespace GNDSoft.Students.Infrastructure.Students.Services
{
    /// <summary>
    /// Сервис по управлению студентами
    /// </summary>
    /// <typeparam name="TStudent">Транспортная модель студента</typeparam>
    /// <typeparam name="TCourse">Транспортная модель курса</typeparam>
    /// <typeparam name="TStudentDto">Транспортная модель студента</typeparam>
    /// <typeparam name="TCourseDto">Транспортная модель курса</typeparam>
    /// <typeparam name="TKey">Тип уникального идентификатора</typeparam>
    public class StudentsService<TStudent, TCourse,
        TStudentDto, TCourseDto,
        TKey> : IStudentsService<TStudentDto, TCourseDto, TKey>
        where TStudentDto : StudentDtoBase<TKey>
        where TCourseDto : CourseDtoBase<TKey>
        where TStudent : StudentBase<TKey>
        where TCourse : CourseBase<TKey>
        where TKey : IEquatable<TKey>
    {
        private readonly IStudentsRepository<TStudent, TCourse, TKey> _studentsRepository;
        private readonly ILogger<StudentsService<TStudent, TCourse, TStudentDto, TCourseDto, TKey>> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор
        /// </summary>
        public StudentsService(IStudentsRepository<TStudent, TCourse, TKey> studentsRepository,
            IMapper mapper,
            ILogger<StudentsService<TStudent, TCourse, TStudentDto, TCourseDto, TKey>> logger = null)
        {
            _studentsRepository = studentsRepository;
            _mapper = mapper;
            _logger = logger;
        }

        /// <inheritdoc />
        public async Task<TStudentDto> AddAsync(TStudentDto dtoModel)
        {
            var entity = _mapper.Map<TStudent>(dtoModel);
            var addedEntry = await _studentsRepository.AddAsync(entity);
            return _mapper.Map<TStudentDto>(addedEntry);
        }

        /// <inheritdoc />
        public async Task<bool> DeleteAsync(TKey id)
        {
            var entity = await _studentsRepository.GetOneByIdAsync(id);
            if(entity == null)
                throw new StudentException($"Student with id {id} not found", GenericExceptionCode<TStudent>.NotFound);
            
            var state = await _studentsRepository.DeleteAsync(entity);
            return state;
        }

        /// <inheritdoc />
        public List<TStudentDto> GetAll()
        {
            var allStudents = _studentsRepository.GetAll().ToList();
            return _mapper.Map<List<TStudentDto>>(allStudents);
        }

        /// <inheritdoc />
        public async Task<List<TStudentDto>> GetAllAsync()
        {
            var allStudents = await _studentsRepository.GetAllAsync();
            return _mapper.Map<List<TStudentDto>>(allStudents);
        }

        /// <inheritdoc />
        public async Task<TStudentDto> GetOneAsync(TKey id)
        {
            var student = await _studentsRepository.GetOneByIdAsync(id);
            return _mapper.Map<TStudentDto>(student);
        }

        /// <inheritdoc />
        public async Task<TStudentDto> GetOneExtendedAsync(TKey id)
        {
            var student = await _studentsRepository.GetOneByIdExtendedAsync(id);
            return _mapper.Map<TStudentDto>(student);
        }

        /// <inheritdoc />
        public async Task<TStudentDto> UpdateAsync(TStudentDto dtoModel)
        {
            var entity = await _studentsRepository.GetOneByIdAsync(dtoModel.Id);
            if(entity == null)
                throw new StudentException($"Student with id {dtoModel.Id} not found", GenericExceptionCode<TStudent>.NotFound);

            _mapper.Map(dtoModel, entity);
            
            var state = await _studentsRepository.DeleteAsync(entity);
            
            return _mapper.Map<TStudentDto>(entity);
        }
    }
}