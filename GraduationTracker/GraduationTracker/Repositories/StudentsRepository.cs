using System.Collections.Generic;
using System.Linq;
using GraduationTracker.Abstraction;
using GraduationTracker.Models;

namespace GraduationTracker.Repositories
{
    public class StudentsRepository : IStudentsRepository
    {
        public Student GetStudent(int id)
        {
            var students = GetStudents();
            return students.FirstOrDefault(x => x.Id == id);
        }

        private List<Student> GetStudents()
        {
            return new List<Student>
            {
                new Student
                {
                    Id = 1,
                    Courses = new Course[]
                    {
                        new Course {Id = 1, Name = "Math", Mark = 95},
                        new Course {Id = 2, Name = "Science", Mark = 95},
                        new Course {Id = 3, Name = "Literature", Mark = 95},
                        new Course {Id = 4, Name = "Physical Education", Mark = 95}
                    }
                },
                new Student
                {
                    Id = 2,
                    Courses = new Course[]
                    {
                        new Course {Id = 1, Name = "Math", Mark = 80},
                        new Course {Id = 2, Name = "Science", Mark = 80},
                        new Course {Id = 3, Name = "Literature", Mark = 80},
                        new Course {Id = 4, Name = "Physical Education", Mark = 80}
                    }
                },
                new Student
                {
                    Id = 3,
                    Courses = new Course[]
                    {
                        new Course {Id = 1, Name = "Math", Mark = 50},
                        new Course {Id = 2, Name = "Science", Mark = 50},
                        new Course {Id = 3, Name = "Literature", Mark = 50},
                        new Course {Id = 4, Name = "Physical Education", Mark = 50}
                    }
                },
                new Student
                {
                    Id = 4,
                    Courses = new Course[]
                    {
                        new Course {Id = 1, Name = "Math", Mark = 40},
                        new Course {Id = 2, Name = "Science", Mark = 40},
                        new Course {Id = 3, Name = "Literature", Mark = 40},
                        new Course {Id = 4, Name = "Physical Education", Mark = 40}
                    }
                }
            };
        }
    }
}