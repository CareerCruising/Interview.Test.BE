using GraduationTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        T GetItem(int Id);
    }
}
