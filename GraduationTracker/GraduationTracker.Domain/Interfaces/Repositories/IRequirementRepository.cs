using GraduationTracker.Domain.Entities;
using System.Collections.Generic;

namespace GraduationTracker.Domain.Interfaces.Repositories
{
    public interface IRequirementRepository : IBaseRepository<Requirement>
    {
        Requirement GetById(int id);
        IEnumerable<Requirement> GetAll();
    }
}
