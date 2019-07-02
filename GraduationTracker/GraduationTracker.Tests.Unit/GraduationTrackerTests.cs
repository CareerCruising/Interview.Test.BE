using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using GraduationTracker.Models;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        private GraduationTracker tracker;

        [TestInitialize]
        public void Init()
        {
            tracker = new GraduationTracker();
        }

        [TestMethod]
        public void HasGraduated_RemedialStudent()
        {
            // Arrange
            var diploma = Helper.GetDiplomas().FirstOrDefault();
            var student = Helper.GetRemedialStudent();
            
            // Act
            STANDING standing;
            var hasGraduated = tracker.HasGraduated(diploma, student, out standing);

            // Assert
            Assert.AreEqual(STANDING.Remedial, standing);
        }

        [TestMethod]
        public void HasGraduated_AverageStudent()
        {
            // Arrange
            var diploma = Helper.GetDiplomas().FirstOrDefault();
            var student = Helper.GetAverageStudent();

            // Act
            STANDING standing;
            var hasGraduated = tracker.HasGraduated(diploma, student, out standing);

            // Assert
            Assert.AreEqual(STANDING.Average, standing);
        }

        [TestMethod]
        public void HasGraduated_MagnaStudent()
        {
            // Arrange
            var diploma = Helper.GetDiplomas().FirstOrDefault();
            var student = Helper.GetMagnaStudent();

            // Act
            STANDING standing;
            var hasGraduated = tracker.HasGraduated(diploma, student, out standing);

            // Assert
            Assert.AreEqual(STANDING.MagnaCumLaude, standing);
        }

        [TestMethod]
        public void HasGraduated_SumaStudent()
        {
            // Arrange
            var diploma = Helper.GetDiplomas().FirstOrDefault();
            var student = Helper.GetSumaStudent();

            // Act
            STANDING standing;
            var hasGraduated = tracker.HasGraduated(diploma, student, out standing);

            // Assert
            Assert.AreEqual(STANDING.SumaCumLaude, standing);
        }

        [TestMethod]
        public void HasGraduated_CreditCriteriaNotMet()
        {
            // Arrange
            var diploma = Helper.GetDiplomas().FirstOrDefault();
            var student = Helper.GetRemedialStudent();

            // Act
            STANDING standing;
            var hasGraduated = tracker.HasGraduated(diploma, student, out standing);

            // Assert
            Assert.IsFalse(hasGraduated);
        }

        [TestMethod]
        public void HasGraduated_NewStudent()
        {
            // Arrange
            var diploma = Helper.GetDiplomas().FirstOrDefault();
            var student = new Student();

            // Act
            STANDING standing;
            var hasGraduated = tracker.HasGraduated(diploma, student, out standing);

            // Assert
            Assert.AreEqual(STANDING.None, standing);
            Assert.IsFalse(hasGraduated);
        }
    }
}