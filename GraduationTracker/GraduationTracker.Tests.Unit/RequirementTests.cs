using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GraduationTracker.Tests
{
    [TestClass()]
    public class RequirementTests
    {
        [TestMethod()]
        public void RequirementTest()
        {
            Requirement requirement = new Requirement(100)
            {
                Name = "Math",
                MinimumMark = 50
            };

            Assert.IsNotNull(requirement);
        }

        [TestMethod()]
        public void IsCoursePartOfRequirementTest()
        {
            Requirement requirement = new Requirement(100)
            {
                Name = "Math",
                MinimumMark = 50
            };

            
            Assert.IsTrue(requirement.IsCoursePartOfRequirement(1));
            Assert.IsFalse(requirement.IsCoursePartOfRequirement(2));
        }

        [TestMethod()]
        public void AreCourseRequirementsMetTestMet()
        {
            StudentCourseRepository studentCourseRepository = new StudentCourseRepository();
            IEnumerable<StudentCourse> studentCourses = studentCourseRepository.GetStudentCourse(2);
            Requirement requirement = new Requirement(100)
            {
                Name = "Math",
                MinimumMark = 50
            };

            Assert.IsTrue(requirement.AreCourseRequirementsMet(studentCourses));
        }

        [TestMethod()]
        public void AreCourseRequirementsMetTestNotMet()
        {
            StudentCourseRepository studentCourseRepository = new StudentCourseRepository();
            IEnumerable<StudentCourse> studentCourses = studentCourseRepository.GetStudentCourse(4);
            Requirement requirement = new Requirement(100)
            {
                Name = "Math",
                MinimumMark = 50
            };

            Assert.IsFalse(requirement.AreCourseRequirementsMet(studentCourses));
        }

        [TestMethod()]
        public void GetCreditsTest()
        {
            Requirement requirement = new Requirement(100)
            {
                Name = "Math",
                MinimumMark = 50
            };

            Assert.IsTrue(requirement.GetCredits() == 1);
        }
    }
}