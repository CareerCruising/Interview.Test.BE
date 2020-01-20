using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        private GraduationTracker Tracker { get; set; }

        public GraduationTrackerTests()
        {
            Tracker = new GraduationTracker();
        }

        private Student GetStudent(int id, int mark, int courses = 4)
        {
            return new Student
            {
                Id = id,
                Courses = GetCourses(id, mark, courses)
            };
        }

        private Course[] GetCourses(int id, int mark, int length)
        {
            var courses = new Course[length];

            for(var i = 0; i < length; i++)
            {
                courses[i] = new Course { Id = i + 1, Name = $"Course {i}", Mark = mark };
            }
            return courses;
        }

        private Diploma GetDiploma(int credits, int[] requirements)
        {
            return new Diploma
            {
                Id = 1,
                Credits = credits,
                Requirements = requirements
            };
        }

        [DataTestMethod]
        [DataRow(100, 95, true, Standing.SumaCumLaude)]
        [DataRow(200, 94, true, Standing.MagnaCumLaude)]
        [DataRow(300, 80, true, Standing.MagnaCumLaude)]
        [DataRow(400, 79, true, Standing.Average)]
        [DataRow(500, 50, true, Standing.Average)]
        [DataRow(600, 49, false, Standing.Remedial)]
        [DataRow(700, 40, false, Standing.Remedial)]
        [DataRow(800, 0, false, Standing.Remedial)]
        public void TestHasGraduated(int id, int mark, bool hasGratuated, Standing standing)
        {
            var diploma = GetDiploma(4, new int[] { 100, 102, 103, 104 });
            var student = GetStudent(id, mark);
            var result = Tracker.HasGraduated(diploma, student);

            Assert.AreEqual(hasGratuated, result.Item1);
            Assert.AreEqual(standing, result.Item2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid diploma.")]
        public void TestInvalidDiploma()
        {
            var student = GetStudent(1, 80);
            Tracker.HasGraduated(null, student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid student.")]
        public void TestInvalidStudent()
        {
            var diploma = GetDiploma(4, new int[] { 100, 102, 103, 104 });
            Tracker.HasGraduated(diploma, null);
        }

        [TestMethod]
        public void TestStudentMissingDiplomaRequirement()
        {
            var diploma = GetDiploma(4, new int[] { 100, 102, 103, 104 });
            var student = GetStudent(1, 100, 3);
            var result = Tracker.HasGraduated(diploma, student);

            Assert.AreEqual(false, result.Item1);
            Assert.AreEqual(Standing.None, result.Item2);
        }
    }
}
