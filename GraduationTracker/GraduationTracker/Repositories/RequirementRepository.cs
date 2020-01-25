using System;

namespace GraduationTracker.Repositories
{
    public class RequirementRepository : IRepository<Requirement>
    {
        public Requirement GetById(int id)
        {
            var requirements = GetRequirements();
            var result = Array.Find(requirements, (requirement => requirement.Id == id));
            return result;
        }

        private static Requirement[] GetRequirements()
        {
            return new[]
            {
                new Requirement{Id = 100, Name = "Math", MinimumMark=50, Courses = new []{1}, Credits=1 },
                new Requirement{Id = 102, Name = "Science", MinimumMark=50, Courses = new []{2}, Credits=1 },
                new Requirement{Id = 103, Name = "Literature", MinimumMark=50, Courses = new []{3}, Credits=1},
                new Requirement{Id = 104, Name = "Physical Education", MinimumMark=50, Courses = new []{4}, Credits=1 }
            };
        }
    }
}