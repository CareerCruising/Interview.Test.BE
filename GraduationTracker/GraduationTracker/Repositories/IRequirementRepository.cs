using GraduationTracker.Models;

namespace GraduationTracker.Repositories
{
    public interface IRequirementRepository
    {
        Requirement GetRequirement(int id);

        Requirement[] GetRequirements();
    }
}
