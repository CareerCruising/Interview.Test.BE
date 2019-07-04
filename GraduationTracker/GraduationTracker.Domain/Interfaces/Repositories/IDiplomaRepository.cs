using GraduationTracker.Domain.Entities;
using System.Collections.Generic;

namespace GraduationTracker.Domain.Interfaces.Repositories
{
    public interface IDiplomaRepository : IBaseRepository<Diploma>
    {
        Diploma GetById(int id);
        IEnumerable<Diploma> GetAll();
    }
}
