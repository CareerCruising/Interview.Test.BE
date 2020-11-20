using GraduationTracker.Domain.Models;

namespace GraduationTracker.Domain.Interfaces
{
    public interface IRequirementRepository
    {
        Requirement[] GetRequirements();
        Requirement GetRequirement(int id);
    }
}
