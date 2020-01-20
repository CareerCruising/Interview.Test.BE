using GraduationTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Repository.Core
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        protected readonly List<TEntity> Context;

        public Repository()
        {
            Context = new List<TEntity>();
        }

        public TEntity Get(int id)
        {
            return Context.FirstOrDefault(entity => entity.GetId() == id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.ToList();
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return Context.Where(predicate);
        }

        public void Add(TEntity entity)
        {
            Context.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Context.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Context.Remove(entity);
            }
        }
    }
}
