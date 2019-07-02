using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraduationTracker.Contract.DataContract;

namespace GraduationTracker.Repositories
{
    class RequirementRepository : IRequirementRepository // Separate Repository for Requirement Data
    {
        readonly IEnumerable<Requirement> requirements = null;
        public RequirementRepository()
        {
            requirements = GetRequirements();

        }
        public IEnumerable<Requirement> GetRequirements()
        {
            return new[]
            {
                    new Requirement{Id = 100, Name = "Math", MinimumMark=50, Courses = new Course[]{ new Course { Id = 1 } }, Credits=1 },
                    new Requirement{Id = 102, Name = "Science", MinimumMark=50, Courses = new Course[]{ new Course { Id = 2 } }, Credits=1 },
                    new Requirement{Id = 103, Name = "Literature", MinimumMark=50, Courses = new Course[]{ new Course { Id = 3 } }, Credits=1},
                    new Requirement{Id = 104, Name = "Physichal Education", MinimumMark=50, Courses = new Course[]{ new Course { Id = 4 } }, Credits=1 }
                };
        }

        public  Requirement GetRequirement(int id)
        {
            //replaced for loops with lambda expression (much cleaner code)             
            return requirements.SingleOrDefault(x => x.Id == id);
        }
    }
}
