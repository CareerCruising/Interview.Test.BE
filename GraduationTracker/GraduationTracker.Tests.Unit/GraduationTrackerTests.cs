using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests.Unit
{
    /// <summary>
    /// Graduation Tracker Tests
    /// </summary>
    [TestClass]
    public class GraduationTrackerTests
    {
        /// <summary>
        /// Test IsDiploma
        /// </summary>
        [TestMethod]
        public void TestIsDiploma()
        {
            //diploma
            var diploma = Repository.GetDiploma(1);
            Assert.IsNotNull(diploma, "Dimploma can't be null");
        }

        /// <summary>
        /// Test HasCredits
        /// </summary>
        [TestMethod]
        public void TestGetStudent()
        {
            //students
            var student = Repository.GetStudent(1);
            Assert.IsNotNull(student, "Student can't be null");
        }

        /// <summary>
        /// Test HasCredits
        /// </summary>
        [TestMethod]
        public void TestHasCredits()
        {
            //diploma
            var diploma = Repository.GetDiploma(1);
            Assert.IsNotNull(diploma, "Dimploma can't be null");

            //students
            var students = GetStudents();
            Assert.IsNotNull(students, "Students can't be null");
            Assert.IsTrue(students.Any(), "Students can't be empty");

            //check
            var graduated = new List<Tuple<bool, Standing, bool>>();
            var tracker = new GraduationTracker();

            foreach (var student in students)
            {
                graduated.Add(tracker.HasGraduated(diploma, student));      
            }

            Assert.IsTrue(graduated.Any(), "None graduated");
            Assert.IsTrue(graduated.Any(x => !x.Item3), "Credits not completed");
        }

        /// <summary>
        /// Test HasGraduated
        /// </summary>
        [TestMethod]
        public void TestHasGraduated()
        {
            //diploma
            var diploma = Repository.GetDiploma(1);
            Assert.IsNotNull(diploma, "Dimploma can't be null");

            //students
            var students = GetStudents();
            Assert.IsNotNull(students, "Students can't be null");
            Assert.IsTrue(students.Any(), "Students can't be empty");

            //check
            var graduated = new List<Tuple<bool, Standing, bool>>();
            var tracker = new GraduationTracker();

            foreach (var student in students)
            {
                graduated.Add(tracker.HasGraduated(diploma, student));
            }

            Assert.IsTrue(graduated.Any(), "None graduated");
            Assert.IsTrue(graduated.Any(x => !x.Item1), "Below average");
        }

        private Student[] GetStudents()
        {
            var students = new[]
            {
                new Student
                {
                    Id = 1,
                    Courses = new[]
                    {
                        new Course {Id = 1, Name = "Math", Mark = 95},
                        new Course {Id = 2, Name = "Science", Mark = 95},
                        new Course {Id = 3, Name = "Literature", Mark = 95},
                        new Course {Id = 4, Name = "Physichal Education", Mark = 95}
                    }
                },
                new Student
                {
                    Id = 2,
                    Courses = new[]
                    {
                        new Course {Id = 1, Name = "Math", Mark = 80},
                        new Course {Id = 2, Name = "Science", Mark = 80},
                        new Course {Id = 3, Name = "Literature", Mark = 80},
                        new Course {Id = 4, Name = "Physichal Education", Mark = 80}
                    }
                },
                new Student
                {
                    Id = 3,
                    Courses = new[]
                    {
                        new Course {Id = 1, Name = "Math", Mark = 50},
                        new Course {Id = 2, Name = "Science", Mark = 50},
                        new Course {Id = 3, Name = "Literature", Mark = 50},
                        new Course {Id = 4, Name = "Physichal Education", Mark = 50}
                    }
                },
                new Student
                {
                    Id = 4,
                    Courses = new[]
                    {
                        new Course {Id = 1, Name = "Math", Mark = 40},
                        new Course {Id = 2, Name = "Science", Mark = 40},
                        new Course {Id = 3, Name = "Literature", Mark = 40},
                        new Course {Id = 4, Name = "Physichal Education", Mark = 40}
                    }
                }
            };

            return students;
        }


    }
}
