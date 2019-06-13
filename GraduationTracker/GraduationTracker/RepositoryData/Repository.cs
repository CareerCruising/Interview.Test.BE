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
                    Name = "Software Engineering", //If it need the subject name
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

       
        public static Student[] GetStudents()
        {
            return new Student[]
            {
                new Student
                {
                    Id = 1,
                    Courses = new CourseMark[]
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
                    Courses = new CourseMark[]
                    {
                        new CourseMark{Id = 1, Name = "Math", Mark=80 },
                        new CourseMark{Id = 2, Name = "Science", Mark=80 },
                        new CourseMark{Id = 3, Name = "Literature", Mark=80 },
                        new CourseMark{Id = 4, Name = "Physichal Education", Mark=80 }
                    }
                },
                new Student
                {
                    Id = 3,
                    Courses = new CourseMark[]
                    {
                        new CourseMark{Id = 1, Name = "Math", Mark=65 },
                        new CourseMark{Id = 2, Name = "Science", Mark=65 },
                        new CourseMark{Id = 3, Name = "Literature", Mark=65 },
                        new CourseMark{Id = 4, Name = "Physichal Education", Mark=65 }
                    }
                },
                new Student
                {
                    Id = 4,
                    Courses = new CourseMark[]
                    {
                        new CourseMark{Id = 1, Name = "Math", Mark=40 },
                        new CourseMark{Id = 2, Name = "Science", Mark=40 },
                        new CourseMark{Id = 3, Name = "Literature", Mark=40 },
                        new CourseMark{Id = 4, Name = "Physichal Education", Mark=40 }
                    }
                }

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
    }
}
