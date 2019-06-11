using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        [TestMethod]
        public void StudentShouldGraduate()
        {
            // Arrange
            var student = Repository.GetStudent(4);
            //student marks 100, 100, 100, 100
            var diploma = Repository.GetDiploma(1);

            // Act
            var graduationTracker = new GraduationTracker();
            ResultGraduationTraker result = graduationTracker.HasGraduated(diploma, student);

            // Assert
            Assert.IsTrue(result.Graduated == true);


        }

        [TestMethod]
        public void StudentShouldGraduateWithSumaCumLaude()
        {
            // Arrange
            Student student = Repository.GetStudent(4);
            //student marks 100, 100, 100, 100
            Diploma diploma = Repository.GetDiploma(1);

            // Act
            GraduationTracker graduationTracker = new GraduationTracker();
            ResultGraduationTraker result = graduationTracker.HasGraduated(diploma, student);

            // Assert
            Assert.IsTrue(result.Graduated == true);
            Assert.IsTrue(result.Standing == Standing.SumaCumLaude);
            // I Don't know exactly how to validate it, as i don't know the business rules.
            Assert.IsTrue(result.TotalCredits > 1);

        }


        [TestMethod]
        public void StudentShouldGraduateWithMagnaCumLaude()
        {
            // Arrange
            Student student = Repository.GetStudent(2);
            //student marks 90, 90, 90, 90
            Diploma diploma = Repository.GetDiploma(1);

            // Act
            GraduationTracker graduationTracker = new GraduationTracker();
            ResultGraduationTraker result = graduationTracker.HasGraduated(diploma, student);

            // Assert
            Assert.IsTrue(result.Graduated == true);
            Assert.IsTrue(result.Standing == Standing.MagnaCumLaude);
            // I Don't know exactly how to validate it, as i don't know the business rules.
            Assert.IsTrue(result.TotalCredits > 1);

        }

        [TestMethod]
        public void StudentShouldGraduateWithAvarage()
        {
            // Arrange
            Student student = Repository.GetStudent(3);
            //student marks 70, 70, 70, 70
            Diploma diploma = Repository.GetDiploma(1);
                       
            // Act
            GraduationTracker graduationTracker = new GraduationTracker();
            ResultGraduationTraker result = graduationTracker.HasGraduated(diploma, student);

            // Assert
            Assert.IsTrue(result.Graduated == true);
            Assert.IsTrue(result.Standing == Standing.Average);
            Assert.IsTrue(result.TotalCredits > 1);

        }

        [TestMethod]
        public void StudentShouldNotGraduate()
        {
            // Arrange
            Student student = Repository.GetStudent(1);
            // student marks 45, 45, 45, 45
            Diploma diploma = Repository.GetDiploma(1);
                       
            // Act
            GraduationTracker graduationTracker = new GraduationTracker();
            ResultGraduationTraker result = graduationTracker.HasGraduated(diploma, student);

            // Assert
            Assert.IsTrue(result.Graduated == false);
            Assert.IsTrue(result.Standing == Standing.Remedial);

        }
    }
}
