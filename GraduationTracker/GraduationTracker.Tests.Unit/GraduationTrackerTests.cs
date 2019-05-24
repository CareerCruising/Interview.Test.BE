using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        readonly GraduationTracker tracker = new GraduationTracker();
        Diploma diploma;
        Student[] students;


        [TestInitialize]
        public void TestInitialize()
        {
            diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            students = new[]
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
        }

        [TestMethod]
        public void TestGetStanding_Remedial()
        {
            var actual = tracker.GetStanding(40);

            Assert.AreEqual(Standing.Remedial, actual);
        }

        [TestMethod]
        public void TestGetStanding_Average()
        {
            var actual = tracker.GetStanding(50);

            Assert.AreEqual(Standing.Average, actual);
        }

        [TestMethod]
        public void TestGetStanding_MagnaCumLaude()
        {
            var actual = tracker.GetStanding(80);

            Assert.AreEqual(Standing.MagnaCumLaude, actual);
        }

        [TestMethod]
        public void TestGetStanding_SumaCumLaude()
        {
            var actual = tracker.GetStanding(95);

            Assert.AreEqual(Standing.SumaCumLaude, actual);
        }

        [TestMethod]
        public void TestHasCredits_Remedial_false()
        {
            var actual = tracker.HasCredits(diploma, students[3]);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void TestHasCredits_true()
        {
            var actual = tracker.HasCredits(diploma, students[1]);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void TestHasGraduated_SumaCumLaude_true()
        {
            var actual = tracker.HasGraduated(diploma, students[0]);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void TestHasGraduated_MagnaCumLaude_true()
        {
            var actual = tracker.HasGraduated(diploma, students[1]);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void TestHasGraduated_Average_true()
        {
            var actual = tracker.HasGraduated(diploma, students[2]);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void TestHasGraduated_Remedial_true()
        {
            var actual = tracker.HasGraduated(diploma, students[3]);

            Assert.IsFalse(actual);
        }
    }
}
