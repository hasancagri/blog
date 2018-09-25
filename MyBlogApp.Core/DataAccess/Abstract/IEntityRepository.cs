using MyBlogApp.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyBlogApp.Core.DataAccess.Abstract
{
    public interface IEntityRepository<T>
        where T : class, IEntity, new()
    {
        List<T> GetList(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
        T Get(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        //Buraya daha sonra tekrar gel
        int Count(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
    }
}
