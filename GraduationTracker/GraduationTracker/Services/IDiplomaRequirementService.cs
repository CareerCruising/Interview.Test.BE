using GraduationTracker.Models;

namespace GraduationTracker.Services
{
    public interface IDiplomaRequirementService : IRequirementService
    {
        Diploma Diploma { get; }
    }
}