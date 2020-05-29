using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dictionary.Repositories.Abstraction;

namespace Dictionary.Repositories.Implementation
{
    public class BaseRepository<TEntity, TDataContext> : IBaseRepository<TEntity> where TEntity : class, new() where TDataContext : DbContext
    {
        protected TDataContext DbContext { get; set; }
        public BaseRepository(TDataContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual TEntity GetById(int id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }
        public virtual TEntity GetByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return DbContext.Set<TEntity>().Where(expression).FirstOrDefault();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbContext.Set<TEntity>().AsNoTracking();
        }
        public virtual IQueryable<TEntity> GetAllByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return DbContext.Set<TEntity>().AsNoTracking().Where(expression);
        }

        public virtual TEntity Create(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
            DbContext.SaveChanges();

            return entity;
        }
        public virtual void Update(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await DbContext.Set<TEntity>().FindAsync(id);
        }
        public virtual Task<TEntity> GetByConditionAsync(Expression<Func<TEntity, bool>> expression)
        {
            return DbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await DbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }
        public virtual async Task<List<TEntity>> GetAllByConditionAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await DbContext.Set<TEntity>().AsNoTracking().Where(expression).ToListAsync();
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
            await DbContext.SaveChangesAsync();

            return entity;
        }
        public virtual async Task UpdateAsync(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }
        public virtual async Task SaveAsync()
        {
            await DbContext.SaveChangesAsync();
        }
        public virtual async Task<List<TEntity>> CreateRangeAsync(List<TEntity> entities)
        {
            DbContext.Set<TEntity>().AddRange(entities);
            await DbContext.SaveChangesAsync();

            return entities;
        }
        public virtual async Task<List<TEntity>> UpdateRangeAsync(List<TEntity> entities)
        {
            DbContext.Set<TEntity>().UpdateRange(entities);
            await DbContext.SaveChangesAsync();

            return entities;
        }
        public virtual async Task DeleteRangeAsync(List<TEntity> entities)
        {
            DbContext.Set<TEntity>().RemoveRange(entities);
            await DbContext.SaveChangesAsync();
        }
        public virtual bool IsEmpty()
        {
            return !DbContext.Set<TEntity>().Any();
        }
        #region Bulk
        public virtual async Task<List<TEntity>> CreateBulkAsync(List<TEntity> entities)
        {
            return entities;
        }
        public virtual async Task<List<TEntity>> DeleteBulkAsync(List<TEntity> entities)
        {
            return entities;
        }
        public virtual async Task<List<TEntity>> UpdateBulkAsync(List<TEntity> entities)
        {
            return entities;
        }
        #endregion
    }

}

