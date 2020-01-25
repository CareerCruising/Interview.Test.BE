using System.Collections.Generic;
using GraduationTracker.Models;

namespace GraduationTracker.Services
{
    public interface IRequirementService
    {
        IEnumerable<Requirement> GetRequirements();
    }
}