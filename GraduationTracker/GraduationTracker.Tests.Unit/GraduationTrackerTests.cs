using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using GraduationTracker.Architecture.Domain.Modules;
using GraduationTracker.Architecture.Repository;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        private readonly GraduationTracker _tracker;
        public GraduationTrackerTests()
        {
            _tracker = new GraduationTracker(new RequirementRepository());
        }

        [TestMethod]
        public void TestHasCredits()
        {
            var diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new[] { new Requirement() { Id = 100 }, new Requirement() { Id = 102 }, new Requirement() { Id = 103 }, new Requirement() { Id = 104 } }
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
            };

            var graduated = students.Select(student => _tracker.HasGraduated(diploma, student)).ToList();
            Assert.IsTrue(graduated.Any());
        }


        [TestMethod]
        public void TestNoHasCredits()
        {
            var diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new[] { new Requirement() { Id = 100 }, new Requirement() { Id = 102 }, new Requirement() { Id = 103 }, new Requirement() { Id = 104 } }
            };

            var students = new[]
            {
               new Student
               {
                   Id = 1,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=40 },
                        new Course{Id = 2, Name = "Science", Mark=30 },
                        new Course{Id = 3, Name = "Literature", Mark=20 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=10 }
                   }
               },
               new Student
               {
                   Id = 2,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=25 },
                        new Course{Id = 2, Name = "Science", Mark=12 },
                        new Course{Id = 3, Name = "Literature", Mark=13 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=9 }
                   }
               }
            };

            var graduated = students.Select(student => _tracker.HasGraduated(diploma, student)).ToList();
            Assert.IsFalse(graduated.Any(x=> x.Item1));
        }
    }
}
