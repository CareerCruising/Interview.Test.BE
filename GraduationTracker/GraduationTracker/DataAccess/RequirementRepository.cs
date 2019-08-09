using GraduationTracker.DataAccess;
using System.Collections.Generic;

namespace GraduationTracker.Repositories
{
    public class RequirementRepository : BaseRepository<Requirement>
    {
        protected override IEnumerable<Requirement> GetAll()
        {
            return new List<Requirement>()
            {
                new Requirement{Id = 100, Name = "Math", MinimumMark=50, Courses = new int[]{1}, Credits=1 },
                new Requirement{Id = 102, Name = "Science", MinimumMark=50, Courses = new int[]{2}, Credits=1 },
                new Requirement{Id = 103, Name = "Literature", MinimumMark=50, Courses = new int[]{3}, Credits=1},
                new Requirement{Id = 104, Name = "Physical Education", MinimumMark=50, Courses = new int[]{4}, Credits=1 }
            };
        }
    }
}