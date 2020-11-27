using System.Collections.Generic;

namespace GraduationTracker.Tests.Unit.Mocks
{
    public class StudentCourseRepositoryMock : StudentCourseRepository
    {
        public StudentCourseRepositoryMock()
        {

        }

        public override IEnumerable<StudentCourse> GetStudentCourse()
        {
            return new List<StudentCourse>()
            {
                new StudentCourse { Id = 1, StudentId = 1, CourseId = 1, Mark = 95 },
                new StudentCourse { Id = 2, StudentId = 1, CourseId = 2, Mark = 95 },
                new StudentCourse { Id = 3, StudentId = 1, CourseId = 3, Mark = 95 },
                new StudentCourse { Id = 4, StudentId = 1, CourseId = 4, Mark = 95 },

                new StudentCourse { Id = 5, StudentId = 2, CourseId = 1, Mark=80 },
                new StudentCourse { Id = 6, StudentId = 2, CourseId = 2, Mark=80 },
                new StudentCourse { Id = 7, StudentId = 2, CourseId = 3, Mark=80 },
                new StudentCourse { Id = 8, StudentId = 2, CourseId = 4, Mark=80 },

                new StudentCourse { Id = 9, StudentId = 3, CourseId = 1, Mark = 50 },
                new StudentCourse { Id = 10, StudentId = 3, CourseId = 2, Mark = 50 },
                new StudentCourse { Id = 11, StudentId = 3, CourseId = 3, Mark = 50 },
                new StudentCourse { Id = 12, StudentId = 3, CourseId = 4, Mark = 50 },

                new StudentCourse { Id = 13, StudentId = 4, CourseId = 1, Mark = 40 },
                new StudentCourse { Id = 14, StudentId = 4, CourseId = 2, Mark = 40 },
                new StudentCourse { Id = 15, StudentId = 4, CourseId = 3, Mark = 40 },
                new StudentCourse { Id = 16, StudentId = 4, CourseId = 4, Mark = 40 },

                new StudentCourse { Id = 17, StudentId = 5, CourseId = 1, Mark = 50 },
                new StudentCourse { Id = 18, StudentId = 5, CourseId = 2, Mark = 50 },
                new StudentCourse { Id = 19, StudentId = 5, CourseId = 3, Mark = 60 },
                new StudentCourse { Id = 20, StudentId = 5, CourseId = 5, Mark = 70 },

                new StudentCourse { Id = 21, StudentId = 6, CourseId = 1, Mark = 95 },
                new StudentCourse { Id = 22, StudentId = 6, CourseId = 2, Mark = 95 },
                new StudentCourse { Id = 23, StudentId = 6, CourseId = 5, Mark = 90 },
                new StudentCourse { Id = 24, StudentId = 6, CourseId = 4, Mark = 90 }
            };
        }
    }
}
