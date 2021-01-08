using System;
using GNDSoft.Students.Infrastructure.Students.Core.DbContexts;
using GNDSoft.Students.Infrastructure.Students.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GNDSoft.Students.Infrastructure.Students.Data.DbContexts
{
    public class StudentsContext: StudentsDbContext<Student, Course, StudentCourse, Guid>
    {
        public StudentsContext(DbContextOptions<StudentsContext> options) : base(options)
        {      }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}