using System.Collections.Generic;

namespace GraduationTracker.Interfaces
{
    interface IDBReader<T>
    {
        List<T> GetItems();
        T GetItemById(int id);
    }
}
