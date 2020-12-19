using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        /** 
         * Failing condition
         * check for student fails
         */
        GraduationTracker tracker;
        public GraduationTrackerTests()
        {
            tracker = new GraduationTracker();
        }
        [TestMethod]
        public void TestHasNotGraduated()
        {
            var diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            var student = new Student
            {
                Id = 4,
                Courses = new Course[]
                {
                        new Course{Id = 1, Name = "Math", Mark=140 },
                        new Course{Id = 2, Name = "Science", Mark=40 },
                        new Course{Id = 3, Name = "Literature", Mark=40 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=40 }
                }
            };
            var graduated = tracker.HasGraduated(diploma, student);

            Assert.IsFalse(graduated.Item1 == true);
        }

        /**
         * Happy path 
         * student graduated 
         */
        [TestMethod]
        public void TestHasGraduated()
        {
            var diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            var student = new Student
            {
                Id = 2,
                Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=80 },
                        new Course{Id = 2, Name = "Science", Mark=80 },
                        new Course{Id = 3, Name = "Literature", Mark=80 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=80 }
                   }
            };

            var graduated = tracker.HasGraduated(diploma, student);

            Assert.IsTrue(graduated.Item1 == true, "Test case has failed");
        }

        /** 
         * Out of Scope path
         * Passing wrong data
         */
        [TestMethod]
        public void TestOutOfScope()
        {
            var diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            var students = new Student[]
            {
                new Student
                {
                    Id = 2,
                    Courses = new Course[]
                    {
                            new Course{Id = 1, Name = "Math", Mark=180 },
                            new Course{Id = 2, Name = "Science", Mark=80 },
                            new Course{Id = 3, Name = "Literature", Mark=80 },
                            new Course{Id = 4, Name = "Physichal Education", Mark=80 }
                    }
                },
                new Student
                {
                    Id = 2,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark=-80 },
                        new Course{Id = 2, Name = "Science", Mark=80 },
                        new Course{Id = 3, Name = "Literature", Mark=80 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=80 }
                   }
                }
            };
            var isGraduated = new List<Tuple<bool, STANDING>>();
            foreach (var stud in students)
            {
                isGraduated.Add(tracker.HasGraduated(diploma, stud));
            }

            Assert.IsFalse(isGraduated.TrueForAll(x => x.Item1 == true));
        }
    }
}
