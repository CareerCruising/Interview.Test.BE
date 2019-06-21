using System.Collections.Generic;
using GraduationTracker.Models;

namespace GraduationTracker.Abstraction
{
    public interface IRequirementsRepository {

        Requirement GetRequirement(int id);
        List<Requirement> GetRequirements();
    }
}