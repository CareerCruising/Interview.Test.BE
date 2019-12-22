using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        [TestMethod]
        public void TestGraduated()
        {
            GraduationTracker tracker = new GraduationTracker();

            Diploma diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            Student student = new Student
            {
                Id = 1,
                Courses = new Course[]
                {
                    new Course { Id = 1, Name = "Math", Mark = 95 },
                    new Course { Id = 2, Name = "Science", Mark = 95 },
                    new Course { Id = 3, Name = "Literature", Mark = 95 },
                    new Course { Id = 4, Name = "Physichal Education", Mark = 95 }
                }
            };

            var response = tracker.HasGraduated(diploma, student);
            bool hasGraduated = response.Item1;
            STANDING standing = response.Item2;

            Assert.IsTrue(hasGraduated);
        }

        [TestMethod]
        public void TestFailedCourses()
        {
            GraduationTracker tracker = new GraduationTracker();

            Diploma diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            Student student = new Student
            {
                Id = 1,
                Courses = new Course[]
                {
                    new Course { Id = 1, Name = "Math", Mark = 95 },
                    new Course { Id = 2, Name = "Science", Mark = 20 },
                    new Course { Id = 3, Name = "Literature", Mark = 95 },
                    new Course { Id = 4, Name = "Physichal Education", Mark = 95 }
                }
            };

            var response = tracker.HasGraduated(diploma, student);
            bool hasGraduated = response.Item1;
            STANDING standing = response.Item2;

            Assert.IsFalse(hasGraduated);

        }

        [TestMethod]
        public void TestMissingCourses()
        {
            GraduationTracker tracker = new GraduationTracker();

            Diploma diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            Student student = new Student
            {
                Id = 1,
                Courses = new Course[]
                {
                    new Course { Id = 1, Name = "Math", Mark = 95 },
                    new Course { Id = 3, Name = "Literature", Mark = 95 },
                    new Course { Id = 4, Name = "Physichal Education", Mark = 95 }
                }
            };

            var response = tracker.HasGraduated(diploma, student);
            bool hasGraduated = response.Item1;
            STANDING standing = response.Item2;

            Assert.IsFalse(hasGraduated);
        }

        [TestMethod]
        public void TestRemedial()
        {
            GraduationTracker tracker = new GraduationTracker();

            Diploma diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            Student student = new Student
            {
                Id = 4,
                Courses = new Course[]
                {
                    new Course { Id = 1, Name = "Math", Mark = 40 },
                    new Course { Id = 2, Name = "Science", Mark = 40 },
                    new Course { Id = 3, Name = "Literature", Mark = 40 },
                    new Course { Id = 4, Name = "Physichal Education", Mark = 40 }
                }
            };

            var response = tracker.HasGraduated(diploma, student);
            bool hasGraduated = response.Item1;
            STANDING standing = response.Item2;

            Assert.AreEqual<STANDING>(standing, STANDING.Remedial);
        }

        [TestMethod]
        public void TestAverage()
        {
            GraduationTracker tracker = new GraduationTracker();

            Diploma diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            Student student = new Student
            {
                Id = 3,
                Courses = new Course[]
                {
                    new Course { Id = 1, Name = "Math", Mark = 50 },
                    new Course { Id = 2, Name = "Science", Mark = 50 },
                    new Course { Id = 3, Name = "Literature", Mark = 50 },
                    new Course { Id = 4, Name = "Physichal Education", Mark = 50 }
                }
            };

            var response = tracker.HasGraduated(diploma, student);
            bool hasGraduated = response.Item1;
            STANDING standing = response.Item2;

            Assert.AreEqual<STANDING>(standing, STANDING.Average);
        }

        [TestMethod]
        public void TestSumaCumLaude()
        {
            GraduationTracker tracker = new GraduationTracker();

            Diploma diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            Student student = new Student
            {
                Id = 2,
                Courses = new Course[]
                {
                    new Course { Id = 1, Name = "Math", Mark = 80 },
                    new Course { Id = 2, Name = "Science", Mark = 80 },
                    new Course { Id = 3, Name = "Literature", Mark = 80 },
                    new Course { Id = 4, Name = "Physichal Education", Mark = 80 }
                }
            };

            var response = tracker.HasGraduated(diploma, student);
            bool hasGraduated = response.Item1;
            STANDING standing = response.Item2;

            Assert.AreEqual<STANDING>(standing, STANDING.SumaCumLaude);
        }

        [TestMethod]
        public void TestMagnaCumLaude()
        {
            GraduationTracker tracker = new GraduationTracker();

            Diploma diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            Student student = new Student
            {
                Id = 1,
                Courses = new Course[]
                {
                    new Course { Id = 1, Name = "Math", Mark = 95 },
                    new Course { Id = 2, Name = "Science", Mark = 95 },
                    new Course { Id = 3, Name = "Literature", Mark = 95 },
                    new Course { Id = 4, Name = "Physichal Education", Mark = 95 }
                }
            };

            var response = tracker.HasGraduated(diploma, student);
            bool hasGraduated = response.Item1;
            STANDING standing = response.Item2;

            Assert.AreEqual<STANDING>(standing, STANDING.MagnaCumLaude);
        }
    }
}
