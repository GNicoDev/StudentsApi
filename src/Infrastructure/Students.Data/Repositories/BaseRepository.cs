using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GNDSoft.Students.Infrastructure.Students.Core.Exceptions;
using GNDSoft.Students.Infrastructure.Students.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GNDSoft.Students.Infrastructure.Students.Data.Repositories
{
    /// <summary>
    /// Реализация интерфейса базового репозитория базового 
    /// </summary>
    /// <typeparam name="TDbContext">Обобщенный контекст</typeparam>
    /// <typeparam name="TEntity">Обобщенная сущность</typeparam>
    /// <typeparam name="TKey">Обобщенный уникальный идентификатор сущности</typeparam>
    public class BaseRepository<TDbContext, TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TDbContext : DbContext
        where TEntity : class
        where TKey : IEquatable<TKey>
    {
        private readonly TDbContext _dbContext;
        private readonly ILogger<BaseRepository<TDbContext, TEntity, TKey>> _logger;

        /// <summary>
        /// Доступ к элементам TEntity
        /// </summary>
        protected DbSet<TEntity> DbSet { get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">Обобщенный контекст</param>
        /// <param name="logger">Logger</param>
        public BaseRepository(TDbContext dbContext, 
            ILogger<BaseRepository<TDbContext, TEntity, TKey>> logger = null)
        {
            _dbContext = dbContext;
            DbSet = _dbContext.Set<TEntity>();
            _logger = logger;
        }

        /// <inheritdoc />
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            try
            {
                await DbSet.AddAsync(entity);
                var res = await CommitAsync();
                
                _logger.LogDebug($"Adding entry {nameof(TEntity)} to db");
                return entity;
            }
            catch (DbUpdateException ex)
            {
                string message = $"Error while add {nameof(TEntity)}";
                _logger.LogError(message, ex);
                throw new BaseException(message, GenericExceptionCode<TEntity>.Create, ex);
            }
        }

        /// <inheritdoc />
        public virtual IEnumerable<TEntity> GetAll() => DbSet;

        /// <inheritdoc />
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            try
            {
                DbSet.Update(entity);
                var res = await CommitAsync();
                 
                _logger.LogDebug($"Update entry {nameof(TEntity)} in db");
                return entity;
            }
            catch (DbUpdateException ex)
            {
                string message = $"Error while update {nameof(TEntity)}";
                _logger.LogError(message, ex);
                throw new BaseException(message, GenericExceptionCode<TEntity>.Update, ex);
            }
        }

        /// <inheritdoc />
        public virtual async Task<bool> DeleteAsync(TEntity entry)
        {
            try
            {
                DbSet.Remove(entry);
                
                _logger.LogDebug($"Delete entry {nameof(TEntity)} from db");
                return await CommitAsync();
            }
            catch (DbUpdateException ex)
            {
                string message = $"Error while delete {nameof(TEntity)}";
                _logger.LogError(message, ex);
                throw new BaseException(message, GenericExceptionCode<TEntity>.Delete, ex);
            }
        }

        /// <inheritdoc />
        public virtual async Task<bool> CommitAsync() =>
            (await _dbContext.SaveChangesAsync()) > 0;
    }
}