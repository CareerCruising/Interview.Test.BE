using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace GraduationTracker.Tests
{
    [TestClass()]
    public class DiplomaTests
    {
        [TestMethod()]
        public void DiplomaTest()
        {
            Diploma diploma = new Diploma(1);

            Assert.IsNotNull(diploma);
            Assert.AreEqual(diploma.Requirements.Count(), 4);
        }

        [TestMethod()]
        public void GetCreditsTest()
        {
            Diploma diploma = new Diploma(1);

            Assert.AreEqual(diploma.GetCredits(), 4);
        }

        [TestMethod()]
        public void IsCoursePartOfDiplomaTestTrue()
        {
            Diploma diploma = new Diploma(1);
            
            Assert.IsTrue(diploma.IsCoursePartOfDiploma(1));
        }

        [TestMethod()]
        public void IsCoursePartOfDiplomaTestFalse()
        {
            Diploma diploma = new Diploma(1);

            Assert.IsFalse(diploma.IsCoursePartOfDiploma(5));
        }

        [TestMethod()]
        public void AreRequirementsMetTestTrue()
        {
            Diploma diploma = new Diploma(1);
            Student student = new Student(diploma, 1);

            Assert.IsTrue(diploma.AreRequirementsMet(student.Courses));
        }

        [TestMethod()]
        public void AreRequirementsMetTestFalse()
        {
            Diploma diploma = new Diploma(1);
            Student student = new Student(diploma, 4);

            Assert.IsFalse(diploma.AreRequirementsMet(student.Courses));
        }
    }
}