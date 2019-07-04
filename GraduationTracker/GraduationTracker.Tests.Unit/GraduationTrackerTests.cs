using GraduationTracker.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        [TestMethod]
        public void TestHasEnoughCredits()
        {
            var diploma = ServiceHelper.GetDiplomaService().GetById(1);
            var students = ServiceHelper.GetStudentService().GetAll();

            var requirements = diploma.Requirements.Select(r => r.Id);
            var hasCredits = students.Select(s => s.Requirements.Where(r => requirements.Contains(r.Id) && r.Valid).Select(r => r.Credits).Sum() >= diploma.Credits);
            
            Assert.IsTrue(hasCredits.Any());
        }

        [TestMethod]
        public void TestNotHasEnoughCredits()
        {
            var diploma = ServiceHelper.GetDiplomaService().GetById(1);
            var student = ServiceHelper.GetStudentService().GetById(4);

            var requirements = diploma.Requirements.Select(r => r.Id);
            var hasEnoughCredits = student.Requirements.Where(r => requirements.Contains(r.Id) && r.Valid).Select(r => r.Credits).Sum() >= diploma.Credits;

            Assert.IsFalse(hasEnoughCredits);
        }

        [TestMethod]
        public void TestGetStudents()
        {
            var students = ServiceHelper.GetStudentService().GetAll();
            Assert.IsTrue(students.Any());
        }

        [TestMethod]
        public void TestGetNotExistStudent()
        {
            var student = ServiceHelper.GetStudentService().GetById(100);
            Assert.IsNull(student);
        }

        [TestMethod]
        public void TestGetDiplomas()
        {
            var diplomas = ServiceHelper.GetDiplomaService().GetAll();
            Assert.IsTrue(diplomas.Any());
        }

        [TestMethod]
        public void TestGetNotExistDiploma()
        {
            var diploma = ServiceHelper.GetDiplomaService().GetById(100);
            Assert.IsNull(diploma);
        }

        [TestMethod]
        public void TestGetCourses()
        {
            var courses = ServiceHelper.GetCourseService().GetAll();
            Assert.IsTrue(courses.Any());
        }

        [TestMethod]
        public void TestGetRequirements()
        {
            var Requirements = ServiceHelper.GetRequirementService().GetAll();
            Assert.IsTrue(Requirements.Any());
        }
        [TestMethod]
        public void TestHasStudentGraduated()
        {
            var students = ServiceHelper.GetStudentService().GetAll();

            Assert.IsTrue(students.Any(s => s.Graduated));
        }
        [TestMethod]
        public void TestHasNotStudentGraduated()
        {
            var students = ServiceHelper.GetStudentService().GetAll();

            Assert.IsTrue(students.Any(s => !s.Graduated));
        }

        [TestMethod]
        public void TestStanding()
        {
            var student = ServiceHelper.GetStudentService().GetById(4);

            Assert.AreEqual(STANDING.Remedial, student.Standing);
        }
    }
}
