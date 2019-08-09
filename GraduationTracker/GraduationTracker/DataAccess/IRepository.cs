using GraduationTracker.Models;

namespace GraduationTracker.DataAccess
{
    public interface IRepository<T> where T : IPrimaryKey
    {
        T GetItem(int Id);  
    }
}
