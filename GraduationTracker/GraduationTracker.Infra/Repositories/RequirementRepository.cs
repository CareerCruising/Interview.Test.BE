using GraduationTracker.Domain.Entities;
using GraduationTracker.Domain.Interfaces.Repositories;
using GraduationTracker.Infra.MocData;
using System.Collections.Generic;

namespace GraduationTracker.Infra.Repositories
{
    public class RequirementRepository : BaseRepository<Requirement>, IRequirementRepository
    {
        public IEnumerable<Requirement> GetAll()
            => RequirementData.GetRequirements();

        public Requirement GetById(int id)
            => RequirementData.GetRequirements().Find(r => r.Id == id);
    }
}
