using System.Collections.Generic;
using GraduationTracker.Models;

namespace GraduationTracker.Tests.Unit
{
    public static class Helper
    {
        public static Student GetRemedialStudent()
        {
            return new Student
            {
                Id = 4,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=40 },
                    new Course{Id = 2, Name = "Science", Mark=40 },
                    new Course{Id = 3, Name = "Literature", Mark=40 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=40 }
                }
            };
        }

        public static Student GetAverageStudent()
        {
            return new Student
            {
                Id = 3,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=50 },
                    new Course{Id = 2, Name = "Science", Mark=50 },
                    new Course{Id = 3, Name = "Literature", Mark=50 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=50 }
                }
            };
        }

        public static Student GetMagnaStudent()
        {
            return new Student
            {
                Id = 2,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=80 },
                    new Course{Id = 2, Name = "Science", Mark=80 },
                    new Course{Id = 3, Name = "Literature", Mark=80 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=80 }
                }
            };
        }

        public static Student GetSumaStudent()
        {
            return new Student
            {
                Id = 1,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=95 },
                    new Course{Id = 2, Name = "Science", Mark=95 },
                    new Course{Id = 3, Name = "Literature", Mark=95 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=95 }
                }
            };
        }

        public static IEnumerable<Student> GetStudents()
        {
            var students = new List<Student>();
            students.Add(GetRemedialStudent());
            students.Add(GetAverageStudent());
            students.Add(GetMagnaStudent());
            students.Add(GetSumaStudent());

            return students;
        }

        public static IEnumerable<Diploma> GetDiplomas()
        {
            return new Diploma[]
            {
                new Diploma
                {
                    Id = 1,
                    Credits = 4,
                    Requirements = new int[] { 100, 102, 103, 104 }
                }
            };
        }
    }
}
