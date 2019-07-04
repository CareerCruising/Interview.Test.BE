using GraduationTracker.Domain.Entities;
using System.Collections.Generic;

namespace GraduationTracker.Infra.MocData
{
    public static class CourseData
    {
        public static List<Course> GetAll()
        {
            return new List<Course>()
            {
                new Course{Id = 1, Name = "Math"},
                new Course{Id = 2, Name = "Science"},
                new Course{Id = 3, Name = "Literature"},
                new Course{Id = 4, Name = "Physichal Education"}
            };
        }

    }
}
