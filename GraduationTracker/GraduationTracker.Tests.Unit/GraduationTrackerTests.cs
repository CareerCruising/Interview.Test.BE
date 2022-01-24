using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraduationTracker.Models;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        [TestMethod]
        public void TestHasGraduated()
        {
            var graduationTracker = new GraduationTracker();

            var diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };
            var student = new Student
            {
                Id = 1
            };

            var graduationStatus = graduationTracker.HasGraduated(diploma, student);

            Assert.IsTrue(graduationStatus);
        }

        [TestMethod]
        public void TestHasNotGraduated()
        {
            var graduationTracker = new GraduationTracker();

            var diploma = new Diploma
            {
                Id = 1,
                Credits = 2,
                Requirements = new int[] { 100, 104 }
            };
            var student = new Student
            {
                Id = 2
            };

            var graduationStatus = graduationTracker.HasGraduated(diploma, student);

            Assert.IsFalse(graduationStatus);
        }
    }
}
