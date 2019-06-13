using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        [TestMethod]
        public void SumaCumLaudeStudent()
        {
            Student student = Repository.GetStudent(1);
            Diploma diploma = Repository.GetDiploma(1);

            // Act
            GraduationTrackerService graduationTracker = new GraduationTrackerService();
            GraduationTraker result = graduationTracker.HasGraduated(diploma, student);

            // Assert
            Assert.IsTrue(result.Graduated == true);
            Assert.IsTrue(result.Standing == Standing.SumaCumLaude);
        }

        [TestMethod]
        public void MagnaCumLaudeStudent()
        {
            Student student = Repository.GetStudent(2);
            Diploma diploma = Repository.GetDiploma(1);

            // Act
            GraduationTrackerService graduationTracker = new GraduationTrackerService();
            GraduationTraker result = graduationTracker.HasGraduated(diploma, student);

            // Assert
            Assert.IsTrue(result.Graduated == true);
            Assert.IsTrue(result.Standing == Standing.MagnaCumLaude);
        }

        [TestMethod]
        public void AverageStudent()
        {
            Student student = Repository.GetStudent(3);
            Diploma diploma = Repository.GetDiploma(1);

            // Act
            GraduationTrackerService graduationTracker = new GraduationTrackerService();
            GraduationTraker result = graduationTracker.HasGraduated(diploma, student);

            // Assert
            Assert.IsTrue(result.Graduated == true);
            Assert.IsTrue(result.Standing == Standing.Average);
        }

        [TestMethod]
        public void RemedialStudent()
        {
            Student student = Repository.GetStudent(4);
            Diploma diploma = Repository.GetDiploma(1);

            // Act
            GraduationTrackerService graduationTracker = new GraduationTrackerService();
            GraduationTraker result = graduationTracker.HasGraduated(diploma, student);

            // Assert
            Assert.IsTrue(result.Graduated == false);
            Assert.IsTrue(result.Standing == Standing.Remedial);
        }

    }
}
