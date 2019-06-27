using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests.Unit
{
    /// <summary>
    /// Tests for the graduation tracker
    /// </summary>
    [TestClass]
    public class GraduationTrackerTests
    {
        /// <summary>
        /// Tests for the sufficent credits
        /// </summary>
        [TestMethod]
        public void TestHasCredits()
        {
            // Diploma predicate
            var diploma = Repository.GetDiploma(1);
            // Throw exception for if null
            Assert.IsNotNull(diploma, "Null diploma exception thrown");

            // Student predicate
            var students = Repository.GetStudents();
            // Throw exception for if null
            Assert.IsNotNull(students, "Null students exception thrown");

            //tracker.HasGraduated()
            var graduated = new List<Tuple<bool, Standing, bool>>();
            var tracker = new GraduationTracker();

            // Loop thru students
            foreach (var student in students)
            {
                // Verify graduation
                graduated.Add(tracker.HasGraduated(diploma, student));
            }

            // Throw exception if no graduates
            Assert.IsTrue(graduated.Any(), "No existing graduates exception thrown");
            Assert.IsTrue(graduated.Any(credit => !credit.Item3, "Insufficient credit exception");
        }

        /// <summary>
        /// Test for diploma
        /// </summary>
        [TestMethod]
        public void TestIsDiploma()
        {
            var diploma = Repository.GetDiploma(1);
            Assert.IsNotNull(diploma, "Null diploma exception thrown");
        }

        /// <summary>
        /// Test for student
        /// </summary>
        [TestMethod]
        public void TestGetStudent()
        {
            var student = Repository.GetStudent(1);
            Assert.IsNotNull(student, "Null student exception thrown");    
        }

        /// <summary>
        /// Test for graduated
        /// </summary>
        [TestMethod]
        public void TestHasGraduated()
        {
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
                    // Mark = 95
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
                    // Mark = 80
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
                    // Mark = 50
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
                    // Mark = 40
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
