using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using GraduationTracker.Interfaces;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        [TestMethod]
        public void GraduatedStandingTest()
        {
            GraduationTrackerTestData graduationTrackerTestData = new GraduationTrackerTestData();
            var tracker = new GraduationTracker(graduationTrackerTestData);

            var actualResult = new List<Tuple<bool, STANDING>>();
            var expectedResult = new List<Tuple<bool, STANDING>>() {
                new Tuple<bool, STANDING>(true, STANDING.SumaCumLaude),
                new Tuple<bool, STANDING>(true, STANDING.MagnaCumLaude),
                new Tuple<bool, STANDING>(true, STANDING.Average),
                new Tuple<bool, STANDING>(false, STANDING.Remedial),
            };

            foreach (var student in graduationTrackerTestData.Students)
            {
                actualResult.Add(tracker.HasGraduated(graduationTrackerTestData.Diplomas[0], student));
            }
            for (int i = 0; i < graduationTrackerTestData.Students.Count; i++)
            {
                Assert.AreEqual(actualResult[i], expectedResult[i]);
            }

        }


    }

    class GraduationTrackerTestData : IDatabase
    {
        public List<Student> Students => new List<Student>() {
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

        public List<Diploma> Diplomas => new List<Diploma>() {
            new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            }
        };

        public List<Requirement> Requirements => new List<Requirement>() {
            new Requirement()
            {
                Id = 100,
                Courses = new int[] {2},
                MinimumMark = 50,
                Credits = 3,
                Name = "Requirement 1"
            },
            new Requirement()
            {
                Id = 102,
                Courses = new int[] {3},
                MinimumMark = 60,
                Credits = 3,
                Name = "Requirement 2"
            },
            new Requirement()
            {
                Id = 103,
                Courses = new int[] {1},
                MinimumMark = 70,
                Credits = 3,
                Name = "Requirement 3"
            },
            new Requirement()
            {
                Id = 104,
                Courses = new int[] {4},
                MinimumMark = 40,
                Credits = 3,
                Name = "Requirement 4"
            }
        };
    }
}
