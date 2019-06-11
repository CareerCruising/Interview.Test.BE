using System.Linq;

namespace GraduationTracker
{
    public class Repository
    {
        public static Student GetStudent(int id)
        {
            Student[] students = GetStudents();
            return students.Where(s => s.Id == id).FirstOrDefault();
        }

        public static Diploma GetDiploma(int id)
        {
            Diploma[] diplomas = GetDiplomas();
            return diplomas.Where(d => d.Id == id).FirstOrDefault();

        }

        public static RequirementCourses GetRequirement(int id)
        {
            RequirementCourses[] requirements = GetRequirements();
            return requirements.Where(r => r.Id == id).FirstOrDefault();
        }

        public static Course GetCourse(int id)
        {
            Course[] courses = GetCourses();
            return courses.Where(c => c.Id == id).FirstOrDefault();
        }


        private static Diploma[] GetDiplomas()
        {
            return new[]
            {
                new Diploma
                {
                    Id = 1,
                    Name = "Computer Science",
                    Credits = 4,
                    Requirements = new RequirementCourses[]{
                                                      GetRequirement(100),
                                                      GetRequirement(102),
                                                      GetRequirement(103),
                                                      GetRequirement(104)
                                                     }
                }
            };
        }

        public static RequirementCourses[] GetRequirements()
        {
            return new RequirementCourses[]
            {
                    new RequirementCourses{Id = 100, Name = "Math", MinimumMark=50, Courses = new Course[]{ GetCourse(1)}, Credits=1 },
                    new RequirementCourses{Id = 102, Name = "Science", MinimumMark=70, Courses = new Course[]{ GetCourse(2) }, Credits=1 },
                    new RequirementCourses{Id = 103, Name = "Literature", MinimumMark=50, Courses = new Course[]{ GetCourse(3) }, Credits=1},
                    new RequirementCourses{Id = 104, Name = "Physichal Education", MinimumMark=50, Courses = new Course[]{ GetCourse(4) }, Credits=1 }
            };
        }

        private static Course[] GetCourses()
        {
            return new Course[]
            {
                new Course{Id = 1, Name = "Math" },
                new Course{Id = 2, Name = "Science" },
                new Course{Id = 3, Name = "Literature" },
                new Course{Id = 4, Name = "Physichal Education" }
            };
        }

        public static Student[] GetStudents()
        {
            return new Student[]
            {
               new Student
               {
                   Id = 1,
                   Name = "Rafael Reis",
                   Courses = new CourseMark[]
                   {
                        new CourseMark{Id = 1, Name = "Math", Mark=45 },
                        new CourseMark{Id = 2, Name = "Science", Mark=45 },
                        new CourseMark{Id = 3, Name = "Literature", Mark=45 },
                        new CourseMark{Id = 4, Name = "Physichal Education", Mark=45 }
                   }
               },
               new Student
               {
                   Id = 2,
                   Courses = new CourseMark[]
                   {
                        new CourseMark{Id = 1, Name = "Math", Mark=90 },
                        new CourseMark{Id = 2, Name = "Science", Mark=90 },
                        new CourseMark{Id = 3, Name = "Literature", Mark=90 },
                        new CourseMark{Id = 4, Name = "Physichal Education", Mark=90 }
                   }
               },
            new Student
            {
                Id = 3,
                Courses = new CourseMark[]
                {
                    new CourseMark{Id = 1, Name = "Math", Mark=70 },
                    new CourseMark{Id = 2, Name = "Science", Mark=70 },
                    new CourseMark{Id = 3, Name = "Literature", Mark=70 },
                    new CourseMark{Id = 4, Name = "Physichal Education", Mark=70 }
                }
            },
            new Student
            {
                Id = 4,
                Courses = new CourseMark[]
                {
                    new CourseMark{Id = 1, Name = "Math", Mark=100 },
                    new CourseMark{Id = 2, Name = "Science", Mark=100 },
                    new CourseMark{Id = 3, Name = "Literature", Mark=100 },
                    new CourseMark{Id = 4, Name = "Physichal Education", Mark=100 }
                }
            }

            };
        }
    }


}
