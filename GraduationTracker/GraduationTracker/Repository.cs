using System.Linq;

namespace GraduationTracker
{
    public class Repository
    {
        public static Course GetCourse(int id)
        {
            var courses = GetCourses();
            return courses.Where(c => c.Id == id).SingleOrDefault();
        }

        public static Diploma GetDiploma(int id)
        {
            var diplomas = GetDiplomas();
            return diplomas.Where(d => d.Id == id).SingleOrDefault();
        }

        public static Requirement GetRequirement(int id)
        {
            var requirements = GetRequirements();
            return requirements.Where(r => r.Id == id).SingleOrDefault();
        }

        public static Student GetStudent(int id)
        {
            var students = GetStudents();
            return students.Where(s => s.Id == id).SingleOrDefault();
        }

        public static StudentCourseMark[] GetStudentCourseMarks()
        {
            return new[]
            {
                new StudentCourseMark { StudentId = 1, CourseId = 1, Mark = 95 },
                new StudentCourseMark { StudentId = 1, CourseId = 2, Mark = 95 },
                new StudentCourseMark { StudentId = 1, CourseId = 3, Mark = 95 },
                new StudentCourseMark { StudentId = 1, CourseId = 4, Mark = 95 },

                new StudentCourseMark { StudentId = 2, CourseId = 1, Mark = 80 },
                new StudentCourseMark { StudentId = 2, CourseId = 2, Mark = 80 },
                new StudentCourseMark { StudentId = 2, CourseId = 3, Mark = 80 },
                new StudentCourseMark { StudentId = 2, CourseId = 4, Mark = 80 },

                new StudentCourseMark { StudentId = 3, CourseId = 1, Mark = 50 },
                new StudentCourseMark { StudentId = 3, CourseId = 2, Mark = 50 },
                new StudentCourseMark { StudentId = 3, CourseId = 3, Mark = 50 },
                new StudentCourseMark { StudentId = 3, CourseId = 4, Mark = 50 },

                new StudentCourseMark { StudentId = 4, CourseId = 1, Mark = 40 },
                new StudentCourseMark { StudentId = 4, CourseId = 2, Mark = 40 },
                new StudentCourseMark { StudentId = 4, CourseId = 3, Mark = 40 },
                new StudentCourseMark { StudentId = 4, CourseId = 4, Mark = 40 },

                new StudentCourseMark { StudentId = 5, CourseId = 1, Mark = 95 },
                new StudentCourseMark { StudentId = 5, CourseId = 2, Mark = 95 },
                new StudentCourseMark { StudentId = 5, CourseId = 3, Mark = 95 },
                new StudentCourseMark { StudentId = 5, CourseId = 4, Mark = 40 }
            };
        }

        private static Course[] GetCourses()
        {
            return new[]
            {
                new Course { Id = 1, Name = "Math", Credits = 1 },
                new Course { Id = 2, Name = "Science", Credits = 1 },
                new Course { Id = 3, Name = "Literature", Credits = 1 },
                new Course { Id = 4, Name = "Physichal Education", Credits = 1 },
            };
        }

        private static Diploma[] GetDiplomas()
        {
            return new[]
            {
                new Diploma
                {
                    Id = 1,
                    Credits = 4,
                    Requirements = new int[] { 100, 102, 103, 104 }
                }
            };
        }

        public static Requirement[] GetRequirements()
        {
            return new[]
            {
                new Requirement{ Id = 100, MinimumMark = 50, Courses = new int[]{ 1 } },
                new Requirement{ Id = 102, MinimumMark = 50, Courses = new int[]{ 2 } },
                new Requirement{ Id = 103, MinimumMark = 50, Courses = new int[]{ 3 } },
                new Requirement{ Id = 104, MinimumMark = 50, Courses = new int[]{ 4 } }
            };
        }

        private static Student[] GetStudents()
        {
            return new[]
            {
               new Student { Id = 1 },
               new Student { Id = 2 },
               new Student { Id = 3 },
               new Student { Id = 4 },
               new Student { Id = 5 }
            };
        }
    }
}
