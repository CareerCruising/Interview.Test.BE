using System.Linq;

/// <summary>
/// Repository.cs file
/// </summary>
namespace GraduationTracker
{
    /// <summary>
    /// Repository class
    /// </summary>
    public class Repository
    {
        /// <summary>
        /// GetStudent method that obtains student via ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>student</returns>
        public static Student GetStudent(int id)
        {
            // Obtain students
            var students = GetStudents();
            // Query individual student based on ID parameter
            var student = students.SingleOrDefault(x => x.Id == id);
            return student;
        }

        /// <summary>
        /// Get diploma based on ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>diploma</returns>
        public static Diploma GetDiploma(int id)
        {
            // Obtain diplomas
            var diplomas = GetDiplomas();
            // Query individual diploma based on ID parameter
            var diploma = diplomas.SingleOrDefault(x => x.Id == id);
            return diploma;
        }

        /// <summary>
        /// GetRequirement method that obtains course requirement based on ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Requirement</returns>
        public static Requirement GetRequirement(int id)
        {
            // Obtain requirements
            var requirements = GetRequirements();
            // Query individual requirement based on ID parameter
            var requirement = requirements.SingleOrDefault(x => x.Id == id);
            return requirement;
        }

        /// <summary>
        /// GetDiplomas method that obtains all diplomas
        /// </summary>
        /// <returns></returns>
        private static Diploma[] GetDiplomas()
        {
            return new[]
            {
                new Diploma
                {
                    // Feed in diploma attribute values
                    Id = 1,
                    Credits = 4,
                    Requirements = new int[]{100,102,103,104}
                }
            };
        }
        /// <summary>
        /// GetRequirements method that obtains all requirements
        /// </summary>
        /// <returns>Requirement</returns>
        public static Requirement[] GetRequirements()
        {   
                return new[]
                {
                    // Explicitly set requirements
                    new Requirement{Id = 100, Name = "Math", MinimumMark=50, Courses = new int[]{1}, Credits=1 },
                    new Requirement{Id = 102, Name = "Science", MinimumMark=50, Courses = new int[]{2}, Credits=1 },
                    new Requirement{Id = 103, Name = "Literature", MinimumMark=50, Courses = new int[]{3}, Credits=1},
                    new Requirement{Id = 104, Name = "Physichal Education", MinimumMark=50, Courses = new int[]{4}, Credits=1 }
                };
        }

        /// <summary>
        /// GetStudents method that obtains students
        /// </summary>
        /// <returns>Students</returns>
        public static Student[] GetStudents()
        {
            return new[]
            {
               new Student
               {
                   // Mark = 95
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
                   // Mark = 80
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
                // Mark = 50
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
                // Mark = 40
                Id = 4,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=40 },
                    new Course{Id = 2, Name = "Science", Mark=40 },
                    new Course{Id = 3, Name = "Literature", Mark=40 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=40 }
                }
            }
            };
        }
    }
}
