using MyBlogApp.Core.DataAccess.Abstract;
using MyBlogApp.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MyBlogApp.Core.DataAccess.Concrete
{
    public class EntityRepositoryBase<TEntity, TContext>
     : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
      where TContext : DbContext, new()
    {
        public virtual void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public virtual void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            using (var context = new TContext())
            {
                var query = (filter == null ? context.Set<TEntity>().AsQueryable() : context.Set<TEntity>().Where(filter));
                return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).FirstOrDefault();
            }
        }

        public virtual List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            using (var context = new TContext())
            {
                var query = (filter == null ? context.Set<TEntity>().AsQueryable() : context.Set<TEntity>().Where(filter));
                return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).ToList();
            }
        }

        public virtual void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public virtual int Count(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            using (var context = new TContext())
            {
                var query = (filter == null ? context.Set<TEntity>().AsQueryable() : context.Set<TEntity>().Where(filter));
                return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).Count();
            }
        }
    }
}
