using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public class Repository
    {

        public static Student GetStudent(int id)
        {
            try
            {
                return GetStudents().Where(x => x.Id == id).SingleOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                throw ex;
            }
        }

        public static Diploma GetDiploma(int id)
        {
            try
            {
                return GetDiplomas().Where(x => x.Id == id).SingleOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                throw ex;
            }
        }

        public static Requirement GetRequirement(int id)
        {
            try
            {
                return GetRequirements().Where(x => x.Id == id).SingleOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                throw ex;
            }
        }

        private static List<Diploma> GetDiplomas()
        {
            return new List<Diploma>
            {
                new Diploma
                {
                    Id = 1,
                    Credits = 4,
                    Requirements = new List<int>{100,102,103,104}
                }
            };
        }

        public static List<Requirement> GetRequirements()
        {
            return new List<Requirement>
                {
                    new Requirement{Id = 100, Name = "Math", MinimumMark=50, Courses = new List<int> {1}, Credits=1 },
                    new Requirement{Id = 102, Name = "Science", MinimumMark=50, Courses = new List<int>{2}, Credits=1 },
                    new Requirement{Id = 103, Name = "Literature", MinimumMark=50, Courses = new List<int>{3}, Credits=1},
                    new Requirement{Id = 104, Name = "Physichal Education", MinimumMark=50, Courses = new List<int>{4}, Credits=1 }
                };
        }
        private static List<Student> GetStudents()
        {
            return new List<Student>
            {
               new Student
               {
                   Id = 1,
                   Courses = new List<Course>
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
                   Courses = new List<Course>
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
                Courses = new List<Course>
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
                Courses = new List<Course>
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
