using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    /// <summary>
    /// This class contains a data repository that will be used by other classes.
    /// </summary>
    public class Repository
    {
        /// <summary>
        /// Query and returns the requirement that matches with the given id.
        /// </summary>
        /// <param name="id">Requirement identification.</param>
        /// <returns>Requirement object if found.</returns>
        public static Requirement GetRequirement(int id)
        {
            Requirement requirement = null;

            var qRequirements = from r in GetRequirements() where r.Id == id select r;
            requirement = qRequirements.Single();

            return requirement;
        }

        /// <summary>
        /// Returns an array of requirements.
        /// </summary>
        /// <returns>Array of Requirement objects.</returns>
        public static Requirement[] GetRequirements()
        {
            return new[]
            {
                new Requirement{Id = 100, Name = "Math", MinimumMark=50, Courses = new int[]{1}, Credits=1 },
                new Requirement{Id = 102, Name = "Science", MinimumMark=50, Courses = new int[]{2}, Credits=1 },
                new Requirement{Id = 103, Name = "Literature", MinimumMark=50, Courses = new int[]{3}, Credits=1},
                new Requirement{Id = 104, Name = "Physichal Education", MinimumMark=50, Courses = new int[]{4}, Credits=1 }
            };
        }

        /// <summary>
        /// Query and returns the diploma that matches with the given id.
        /// </summary>
        /// <param name="id">Diploma identification.</param>
        /// <returns>Diploma object if found.</returns>
        public static Diploma GetDiploma(int id)
        {
            Diploma diploma = null;

            var qDiplomas = from d in GetDiplomas() where d.Id == id select d;
            diploma = qDiplomas.Single();

            return diploma;
        }

        /// <summary>
        /// Returns an array of diplomas.
        /// </summary>
        /// <returns>Array of Diploma objects.</returns>
        public static Diploma[] GetDiplomas()
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

        /// <summary>
        /// Query and returns the student that matches with the given id.
        /// </summary>
        /// <param name="id">Student identification.</param>
        /// <returns>Student object if found.</returns>
        public static Student GetStudent(int id)
        {
            Student student = null;

            // Query and return the student that matches with the given id
            var qStudents = from s in GetStudents() where s.Id == id select s;
            student = qStudents.Single();

            return student;
        }

        /// <summary>
        /// Returns an array of students.
        /// </summary>
        /// <returns>Array of Student objects.</returns>
        public static Student[] GetStudents()
        {
            return new[]
            {
               new Student
               {
                   Id = 1,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 3, Name = "Literature", Mark=95 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=95 }
                   }
               },
               new Student
               {
                   Id = 2,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=80 },
                        new Course{Id = 2, Name = "Science", Mark=80 },
                        new Course{Id = 3, Name = "Literature", Mark=80 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=80 }
                   }
               },
                new Student
                {
                    Id = 3,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark=50 },
                        new Course{Id = 2, Name = "Science", Mark=50 },
                        new Course{Id = 3, Name = "Literature", Mark=50 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=50 }
                    }
                },
                new Student
                {
                    Id = 4,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark=40 },
                        new Course{Id = 2, Name = "Science", Mark=40 },
                        new Course{Id = 3, Name = "Literature", Mark=40 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=40 }
                    }
                },
                new Student
                {
                    Id = 5,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=80 },
                        new Course{Id = 3, Name = "Literature", Mark=50 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=40 }
                    }
                },
                new Student
                {
                    Id = 6,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark=80 },
                        new Course{Id = 2, Name = "Science", Mark=40 },
                        new Course{Id = 3, Name = "Literature", Mark=25 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=40 }
                    }
                }
            };
        }
    }
}