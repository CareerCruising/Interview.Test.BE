using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void IsStudentValidTest()
        {
            var student = Repository.GetStudent(2);
            Assert.IsTrue(student.Id == 2);
            Assert.IsTrue(student.Courses != null);
            Assert.IsTrue(student.Courses.Any(m => m.Mark >= 0 && m.Mark<=100));


        }

        [TestMethod]
        public void IsDiplomaValidTest()
        {
            var diploma = Repository.GetDiploma(1);
            Assert.IsTrue(diploma != null);
            Assert.IsFalse(diploma.Id == 2);        
            Assert.IsTrue(diploma.Credits >= 0);
            Assert.IsTrue(diploma.Requirements.Contains(102));
           

        }
        [TestMethod]
        public void IsRequirementValidTest()
        {
            var requirement = Repository.GetRequirement(102);
            Assert.IsTrue(requirement != null);
            Assert.IsTrue(requirement.MinimumMark>49);
            Assert.IsTrue(requirement.Credits==1);

        }
    }
}
