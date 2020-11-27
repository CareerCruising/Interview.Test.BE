using System.Collections.Generic;

namespace GraduationTracker.Tests.Unit.Mocks
{
    public class CourseRepositoryMock : CourseRepository
    {
        public CourseRepositoryMock()
        { 
        
        }

        public override IEnumerable<Course> GetCourse()
        {
            return new List<Course>()
            {
                new Course { Id = 1, Name = "Math", Credits = 1},
                new Course { Id = 2, Name = "Science", Credits = 1 },
                new Course { Id = 3, Name = "Literature", Credits = 1 },
                new Course { Id = 4, Name = "Physical Education", Credits = 2 },
                new Course { Id = 5, Name = "Business", Credits = 1 }
            };
        }
    }
}
