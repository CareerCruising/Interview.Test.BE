using System.Collections.Generic;
using System.Linq;
using GraduationTracker.Abstraction;
using GraduationTracker.Models;

namespace GraduationTracker.Repositories
{
    public class RequirementsRepository : IRequirementsRepository
    {
        public Requirement GetRequirement(int id)
        {
            var requirements = GetRequirements();
            return requirements.FirstOrDefault(x => x.Id == id);
        }

        public List<Requirement> GetRequirements()
        {
            return new List<Requirement>
            {
                new Requirement {Id = 100, Name = "Math", MinimumMark = 50, Courses = new int[] {1}, Credits = 1},
                new Requirement {Id = 102, Name = "Science", MinimumMark = 50, Courses = new int[] {2}, Credits = 1},
                new Requirement {Id = 103, Name = "Literature", MinimumMark = 50, Courses = new int[] {3}, Credits = 1},
                new Requirement {Id = 104, Name = "Physical Education", MinimumMark = 50, Courses = new int[] {4}, Credits = 1}
            };
        }
    }
}