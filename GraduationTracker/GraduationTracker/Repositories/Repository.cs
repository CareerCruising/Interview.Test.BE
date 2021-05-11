using System.Collections.Generic;
using System.Linq;
using GraduationTracker.Courses;
using GraduationTracker.Diplomas;
using GraduationTracker.Students;

namespace GraduationTracker.Repositories
{
    public class Repository
    {
        public static IStudent GetStudent(int id)
        {
            IEnumerable<IStudent> students = GetStudents();
            return students.Where(st => st.Id == id).FirstOrDefault();
        }

        public static IDiploma GetDiploma(int id)
        {
            IEnumerable<IDiploma> diplomas = GetDiplomas();
            return diplomas.Where(dip => dip.Id == id).FirstOrDefault();

        }

        public static IRequirement GetRequirement(int id)
        {
            IEnumerable<IRequirement> requirements = GetRequirements();
            return requirements.Where(req => req.Id == id).FirstOrDefault();
        }

        public static ICourse GetCourse(int id)
        {
            IEnumerable<ICourse> courses = GetCourses();
            return courses.Where(c => c.Id == id).FirstOrDefault();
        }


        private static IEnumerable<Diploma> GetDiplomas()
        {
            return new List<Diploma>
            {
                new Diploma
                {
                    Id = 1,
                    Requirements = new List<IRequirement>{GetRequirement(100), GetRequirement(102), GetRequirement(103), GetRequirement(104)}
                }
            };
        }

        public static IEnumerable<ICourse> GetCourses()
        {
            return new List<ICourse>
            {
                new Course{Id = 1, Name = "Math" },
                new Course{Id = 2, Name = "Science" },
                new Course{Id = 3, Name = "Literature" },
                new Course{Id = 4, Name = "Physichal Education" }
            };
        }

        public static IEnumerable<IRequirement> GetRequirements()
        {   
                return new List<IRequirement>
                {
                    new Requirement{Id = 100, Course = GetCourse(1), MinimumMark=50, Credits=1 },
                    new Requirement{Id = 102, Course = GetCourse(2), MinimumMark=50,  Credits=1 },
                    new Requirement{Id = 103, Course = GetCourse(3), MinimumMark=50, Credits=1},
                    new Requirement{Id = 104, Course = GetCourse(4), MinimumMark=50, Credits=1 }
                };
        }
        public static IEnumerable<IStudent> GetStudents()
        {
            return new List<IStudent>
            {
               new Student
               {
                   Id = 1,
                   CoursesMark = new CourseMark[]
                   {
                        new CourseMark{Id = 1, Name = "Math", Mark=95 },
                        new CourseMark{Id = 2, Name = "Science", Mark=95 },
                        new CourseMark{Id = 3, Name = "Literature", Mark=95 },
                        new CourseMark{Id = 4, Name = "Physichal Education", Mark=95 }
                   }
               },
               new Student
               {
                   Id = 2,
                   CoursesMark = new CourseMark[]
                   {
                        new CourseMark{Id = 1, Name = "Math", Mark=80 },
                        new CourseMark {Id = 2, Name = "Science", Mark=80 },
                        new CourseMark{Id = 3, Name = "Literature", Mark=80 },
                        new CourseMark{Id = 4, Name = "Physichal Education", Mark=80 }
                   }
               },
            new Student
            {
                Id = 3,
                CoursesMark = new CourseMark[]
                {
                    new CourseMark{Id = 1, Name = "Math", Mark=50 },
                    new CourseMark{Id = 2, Name = "Science", Mark=40 },
                    new CourseMark{Id = 3, Name = "Literature", Mark=50 },
                    new CourseMark{Id = 4, Name = "Physichal Education", Mark=50 }
                }
            },
            new Student
            {
                Id = 4,
                CoursesMark = new CourseMark[]
                {
                    new CourseMark{Id = 1, Name = "Math", Mark=40 },
                    new CourseMark{Id = 2, Name = "Science", Mark=40 },
                    new CourseMark{Id = 3, Name = "Literature", Mark=40 },
                    new CourseMark{Id = 4, Name = "Physichal Education", Mark=40 }
                }
            }

            };
        }
    }


}
