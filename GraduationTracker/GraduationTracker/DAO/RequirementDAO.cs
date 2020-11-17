using GraduationTracker.Interfaces;
using System.Collections.Generic;

namespace GraduationTracker
{
    public class RequirementDAO : IDBReader<Requirement>
    {
        IDatabase _database;
        public RequirementDAO(IDatabase database)
        {
            this._database = database;
        }

        public Requirement GetItemById(int id)
        {
            return this._database.Requirements.Find(requirement => requirement.Id == id);
        }

        public List<Requirement> GetItems()
        {
            return this._database.Requirements;
        }
    }
}
