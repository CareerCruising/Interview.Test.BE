using GraduationTracker.Models;
using GraduationTracker.Models.Interfaces;

namespace GraduationTracker.Data
{
    public class SeedingData
    {
        //Implementing interface here will make the code loosly couple
        public IStudent[] GetStudents()
        {
            return new[]
            {
               new Student
               {
                   Id = 1,
                   StudentCourses = new int[]
                   {
                       1,
                       2,
                       3,
                       4
                   },
               },
               new Student
               {
                   Id = 2,
                   StudentCourses = new int[]
                   {
                       1,
                       2,
                       3,
                       4
                   },
               },
            new Student
            {
                Id = 3,
                StudentCourses = new int[]
                {
                      1,
                      2,
                      3,
                      4
                },
            },
            new Student
            {
                Id = 4,
                StudentCourses = new int[]
                {
                      1,
                      2,
                      3,
                      4
                },
            }
            };
        }

        public IDiploma[] GetDiplomas()
        {
            return new[]
{
                new Diploma
                {
                    Id = 1,
                    Credits = 4,
                    Requirements = new int[]{100,102,103,104}
                }
            };
        }

        public ICourse[] GetCourses()
        {
            return new Course[] {
                new Course { Id = 1, Name = "Math"},
                        new Course { Id = 2, Name = "Science"},
                        new Course { Id = 3, Name = "Literature"},
                        new Course { Id = 4, Name = "Physichal Education"}
                   };
        }

        public IRequirement[] GetRequirements()
        {
            return new[]
               {
                    new Requirement{Id = 100, Name = "Math", MinimumMark=50, Course = 1, Credits=1 },
                    new Requirement{Id = 102, Name = "Science", MinimumMark=50, Course = 2, Credits=1 },
                    new Requirement{Id = 103, Name = "Literature", MinimumMark=50, Course = 3, Credits=1},
                    new Requirement{Id = 104, Name = "Physichal Education", MinimumMark=50, Course = 4, Credits=1 }
                };
        }

        public IStudentCourse[] GetStudentCourses()
        {
            return new[]
               {
                    new StudentCourse{Id = 1, Course = 1, Student = 1, Mark = 50 },
                    new StudentCourse{Id = 2, Course = 2, Student = 1, Mark = 50 },
                    new StudentCourse{Id = 3, Course = 3, Student = 1, Mark = 50 },
                    new StudentCourse{Id = 4, Course = 4, Student = 1, Mark = 50 },

                    new StudentCourse{Id = 5, Course = 1, Student = 2, Mark = 49 },
                    new StudentCourse{Id = 8, Course = 4, Student = 2, Mark = 42 },
                };
        }
    }
}
