using GraduationTracker.Interfaces;
using System.Collections.Generic;

namespace GraduationTracker
{
    class DiplomaDAO : IDBReader<Diploma>
    {
        IDatabase _database;
        public DiplomaDAO(IDatabase database)
        {
            this._database = database;
        }

        public Diploma GetItemById(int id)
        {
            return this._database.Diplomas.Find(diploma => diploma.Id == id);
        }

        public List<Diploma> GetItems()
        {
            return this._database.Diplomas;
        }
    }
}
