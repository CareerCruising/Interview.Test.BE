using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using GraduationTracker.Models;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        [TestMethod]
        public void TestHasCredits()
        {
            var tracker = new GraduationTracker();

            var diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            var students = new[]
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
            }


            //tracker.HasGraduated()
        };
            
            var graduated = new List<GraduatedModel>();

            //We should avoid if, while, for, and switch logic in the test cases
            //But, for this specific scenario we can keep this
            foreach (var student in students)
            {
                graduated.Add(tracker.HasGraduated(diploma, student));      
            }

            Assert.IsTrue(graduated.Any());

        }


        [TestMethod]
        public void TestHasGraduated_WithLowMarks_ReturnsFalseAndRemedialStanding()
        {
            var tracker = new GraduationTracker();

            // Arrange
            var diploma = new Diploma { Requirements = new int[] { 100 } };
            var student = new Student { Courses = new Course[] { new Course { Id = 1, Name = "Math", Mark = 45 } } };

            // Act
            var result = tracker.HasGraduated(diploma, student);

            // Assert
            Assert.AreEqual(false, result.IsGraduated);
            Assert.AreEqual(STANDING.Remedial, result.Standing);
        }

        [TestMethod]
        public void TestHasGraduated_WithAverageMarks_ReturnsTrueAndAverageStanding()
        {
            var tracker = new GraduationTracker();

            // Arrange
            var diploma = new Diploma { Requirements = new int[] { 100 } };
            var student = new Student { Courses = new Course[] { new Course { Id = 1, Name = "Math", Mark = 75 } } };

            // Act
            var result = tracker.HasGraduated(diploma, student);

            // Assert
            Assert.AreEqual(true, result.IsGraduated);
            Assert.AreEqual(STANDING.Average, result.Standing);
        }


        [TestMethod]
        public void TestHasGraduated_WithAverageMarks_ReturnsTrueAndMagnaCumLaudeStanding()
        {
            var tracker = new GraduationTracker();

            // Arrange
            var diploma = new Diploma { Requirements = new int[] { 100 } };
            var student = new Student { Courses = new Course[] { new Course { Id = 1, Name = "Math", Mark = 90 } } };

            // Act
            var result = tracker.HasGraduated(diploma, student);

            // Assert
            Assert.AreEqual(true, result.IsGraduated);
            Assert.AreEqual(STANDING.MagnaCumLaude, result.Standing);
        }


        [TestMethod]
        public void TestHasGraduated_WithInvalidDiploma_ReturnsFalseAndNoneStanding()
        {
            var tracker = new GraduationTracker();

            // Arrange
            var diploma = new Diploma { Requirements = new int[] { 100 } };
            var student = new Student { Courses = new Course[] { new Course { Id = 5, Name = "Math", Mark = 90 } } };

            // Act
            var result = tracker.HasGraduated(diploma, student);

            // Assert
            Assert.AreEqual(false, result.IsGraduated);
            Assert.AreEqual(STANDING.None, result.Standing);
        }

    }
}
