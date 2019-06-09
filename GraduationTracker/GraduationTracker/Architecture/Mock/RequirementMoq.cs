using System.Collections.Generic;
using GraduationTracker.Architecture.Domain.Modules;

namespace GraduationTracker.Architecture.Mock
{

    public class RequirementMoq
    {
        public static IEnumerable<Requirement> GetRequirements()
        {
            return new[]
            {
                new Requirement{Id = 100, Name = "Math", MinimumMark=50, Courses = new Course[]{ new Course { Id = 1 } }, Credits=1 },
                new Requirement{Id = 102, Name = "Science", MinimumMark=50, Courses = new Course[]{ new Course { Id = 2 } }, Credits=1 },
                new Requirement{Id = 103, Name = "Literature", MinimumMark=50, Courses = new Course[]{ new Course { Id = 3 } }, Credits=1},
                new Requirement{Id = 104, Name = "Physichal Education", MinimumMark=50, Courses = new Course[]{ new Course { Id = 4 } }, Credits=1 }
            };
        }
    }
}
