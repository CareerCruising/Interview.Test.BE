using GraduationTracker.DML;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.DAL
{
    public class DStudent
    {
        /// <summary>
        /// Get Student details by Id
        /// </summary>
        /// <param name="id">Student Id</param>
        /// <returns>Return Student object filled data by Id</returns>
        public static Student GetStudent(int id)
        {
            return GetStudents().SingleOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Get List of Student
        /// </summary>
        /// <returns>Return List of Student encountered</returns>
        public static List<Student> GetStudents()
        {
            return new List<Student> {
                new Student {
                    Id = 1,
                    Courses = new List<Course> {
                        new Course {Id = 1, Name = "Math", Mark = 95 },
                        new Course {Id = 2, Name = "Science", Mark = 95 },
                        new Course {Id = 3, Name = "Literature", Mark = 95 },
                        new Course {Id = 4, Name = "Physichal Education", Mark = 95 }
                    }
                },
                new Student {
                    Id = 2,
                    Courses = new List<Course> {
                        new Course {Id = 1, Name = "Math", Mark=80 },
                        new Course {Id = 2, Name = "Science", Mark=80 },
                        new Course {Id = 3, Name = "Literature", Mark=80 },
                        new Course {Id = 4, Name = "Physichal Education", Mark=80 }
                    }
                },
                new Student {
                    Id = 3,
                    Courses = new List<Course> {
                        new Course{Id = 1, Name = "Math", Mark = 50 },
                        new Course{Id = 2, Name = "Science", Mark = 50 },
                        new Course{Id = 3, Name = "Literature", Mark = 50 },
                        new Course{Id = 4, Name = "Physichal Education", Mark = 50 }
                    }
                },
                new Student {
                    Id = 4,
                    Courses = new List<Course> {
                        new Course{Id = 1, Name = "Math", Mark = 40 },
                        new Course{Id = 2, Name = "Science", Mark = 40 },
                        new Course{Id = 3, Name = "Literature", Mark = 40 },
                        new Course{Id = 4, Name = "Physichal Education", Mark = 40 }
                    }
                }

            };
        }
    }
}
