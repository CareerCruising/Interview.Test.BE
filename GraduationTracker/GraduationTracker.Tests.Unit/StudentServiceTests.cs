using GraduationTracker.Models;
using GraduationTracker.Repositories;
using GraduationTracker.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraduationTracker.Tests.Unit
{
    [TestClass()]
    public class StudentServiceTests
    {
        [TestMethod()]
        public void GetStandingTest_StudentStandingSuma()
        {
            // Arrange 
            var studentRepository = new StudentRepository();
            var student = studentRepository.GetById(1);
            var studentService = new StudentService(student);

            // Act 
            var actual = studentService.GetStanding();

            // Assert
            Assert.AreEqual(Standing.SumaCumLaude, actual);

        }

        [TestMethod()]
        public void GetStandingTest_StudentStandingMagna()
        {
            // Arrange 
            var studentRepository = new StudentRepository();
            var student = studentRepository.GetById(2);
            var studentService = new StudentService(student);

            // Act 
            var actual = studentService.GetStanding();

            // Assert
            Assert.AreEqual(Standing.MagnaCumLaude, actual);

        }

        [TestMethod()]
        public void GetStandingTest_StudentStandingAverage()
        {
            // Arrange 
            var studentRepository = new StudentRepository();
            var student = studentRepository.GetById(3);
            var studentService = new StudentService(student);

            // Act 
            var actual = studentService.GetStanding();

            // Assert
            Assert.AreEqual(Standing.Average, actual);

        }


        [TestMethod()]
        public void GetStandingTest_StudentStandingRemedial()
        {
            // Arrange 
            var studentRepository = new StudentRepository();
            var student = studentRepository.GetById(4);
            var studentService = new StudentService(student);

            // Act 
            var actual = studentService.GetStanding();

            // Assert
            Assert.AreEqual(Standing.Remedial, actual);

        }

        [TestMethod()]
        public void CalculateCreditsTest()
        {
            // Arrange 
            var diplomaRepository = new DiplomaRepository();
            var diploma = diplomaRepository.GetById(1);
            var studentRepository = new StudentRepository();
            var student = studentRepository.GetById(1);
            var diplomaService = new DiplomaService(diploma, new RequirementRepository());
            var studentService = new StudentService(student);

            // Act 
            var actual = studentService.CalculateCredits(diplomaService.GetRequirements());

            // Assert
            Assert.AreEqual(4, actual);
        }
    }
}