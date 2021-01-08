using System;
using GNDSoft.Students.Infrastructure.Students.Core.Models.Entityes;
using Microsoft.EntityFrameworkCore;

namespace GNDSoft.Students.Infrastructure.Students.Core.DbContexts
{
    public class StudentsDbContext<TStudent, TCourse, TStudentCourse, TKey> : DbContext
        where TStudent : StudentBase<TKey>
        where TCourse : CourseBase<TKey>
        where TStudentCourse : StudentCourceBase<TStudent, TCourse, TKey>
        where TKey : IEquatable<TKey>
    {
        public StudentsDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<TStudent> Students { get; set; }
        public DbSet<TCourse> Cources { get; set; }
        public DbSet<TStudentCourse> StudentCources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}