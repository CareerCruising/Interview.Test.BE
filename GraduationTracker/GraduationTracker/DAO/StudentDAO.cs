using GraduationTracker.Interfaces;
using System.Collections.Generic;

namespace GraduationTracker
{
    class StudentDAO : IDBReader<Student>
    {
        IDatabase _database;
        public StudentDAO(IDatabase database)
        {
            this._database = database;
        }

        public Student GetItemById(int id)
        {
            return this._database.Students.Find(student => student.Id == id);
        }

        public List<Student> GetItems()
        {
            return this._database.Students;
        }
    }
}
