using System.Linq;
using GraduationTracker.Architecture.Domain.Modules;
using GraduationTracker.Architecture.Domain.Modules.Repository;
using GraduationTracker.Architecture.Mock;

namespace GraduationTracker.Architecture.Repository
{
    public class RequirementRepository : IRequirementRepository
    {
        public Requirement GetRequirement(int id)
        {
            return RequirementMoq.GetRequirements().SingleOrDefault(x => x.Id == id);
        }
    }
}
