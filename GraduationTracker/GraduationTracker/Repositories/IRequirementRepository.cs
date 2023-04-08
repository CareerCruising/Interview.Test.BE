using GraduationTracker.Models;
using System.Collections.Generic;

namespace GraduationTracker.Repositories
{
    public interface IRequirementRepository
    {
        Requirement GetRequirement(int id);

        IEnumerable<Requirement> GetRequirements();
    }
}
