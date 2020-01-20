using GraduationTracker.Model;
using System;
using System.Collections.Generic;

namespace GraduationTracker.Repository.Core
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
