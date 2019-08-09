using System.Collections.Generic;
using System.Linq;
using GraduationTracker.Models;

namespace GraduationTracker.DataAccess
{
    public abstract class BaseRepository<T> : IRepository<T> where T : IPrimaryKey
    {
        public T GetItem(int Id)
        {
            return GetAll().FirstOrDefault(x => x.Id == Id);
        }

        protected abstract IEnumerable<T> GetAll();
    }
}
