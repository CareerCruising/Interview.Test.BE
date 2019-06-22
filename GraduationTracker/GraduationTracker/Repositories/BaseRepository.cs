using GraduationTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T: IEntity
    {
        public T GetItem(int Id)
        {
            return GetAll().FirstOrDefault(x => x.Id == Id);
        }

        protected abstract IEnumerable<T> GetAll();
    }
}
