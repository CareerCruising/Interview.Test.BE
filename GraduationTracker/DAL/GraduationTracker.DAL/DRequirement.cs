using GraduationTracker.DML;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.DAL
{
    public class DRequirement
    {
        /// <summary>
        /// Get Requirement details by Id
        /// </summary>
        /// <param name="id">Requirement Id</param>
        /// <returns>Return Requirement object filled data by Id</returns>
        public static Requirement GetRequirement(int id)
        {
            return GetRequirements().SingleOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Get List of Requirement
        /// </summary>
        /// <returns>Return List of Requirement encountered</returns>
        public static List<Requirement> GetRequirements()
        {
            return new List<Requirement> {
                new Requirement { Id = 100, Name = "Math", MinimumMark = 50, Courses = new List<Course> { new Course { Id = 1 } }, Credits = 1 },
                new Requirement { Id = 102, Name = "Science", MinimumMark = 50, Courses = new List<Course> { new Course { Id = 2 } }, Credits = 1 },
                new Requirement { Id = 103, Name = "Literature", MinimumMark = 50, Courses = new List<Course> { new Course { Id = 3 } }, Credits = 1 },
                new Requirement { Id = 104, Name = "Physichal Education", MinimumMark = 50, Courses = new List<Course> { new Course { Id = 4 } }, Credits = 1 }
            };
        }
    }
}
