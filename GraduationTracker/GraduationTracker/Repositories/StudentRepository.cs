using System;
using GraduationTracker.Models;

namespace GraduationTracker.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        public Student GetById(int id)
        {
            var students = GetStudents();
            var result = Array.Find(students, (student => student.Id == id));
            return result;
        }

        private static Student[] GetStudents()
        {
            return new[]
            {
               new Student
               {
                   Id = 1,
                   Courses = new[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 3, Name = "Literature", Mark=95 },
                        new Course{Id = 4, Name = "Physical Education", Mark=95 }
                   }
               },
               new Student
               {
                   Id = 2,
                   Courses = new []
                   {
                        new Course{Id = 1, Name = "Math", Mark=80 },
                        new Course{Id = 2, Name = "Science", Mark=80 },
                        new Course{Id = 3, Name = "Literature", Mark=80 },
                        new Course{Id = 4, Name = "Physical Education", Mark=80 }
                   }
               },
            new Student
            {
                Id = 3,
                Courses = new []
                {
                    new Course{Id = 1, Name = "Math", Mark=50 },
                    new Course{Id = 2, Name = "Science", Mark=50 },
                    new Course{Id = 3, Name = "Literature", Mark=50 },
                    new Course{Id = 4, Name = "Physical Education", Mark=50 }
                }
            },
            new Student
            {
                Id = 4,
                Courses = new []
                {
                    new Course{Id = 1, Name = "Math", Mark=40 },
                    new Course{Id = 2, Name = "Science", Mark=40 },
                    new Course{Id = 3, Name = "Literature", Mark=40 },
                    new Course{Id = 4, Name = "Physical Education", Mark=40 }
                }
            }

            };
        }

    }
}
