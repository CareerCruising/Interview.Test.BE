using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        [DataTestMethod]
        [DataRow(int.MinValue, STANDING.None)]
        [DataRow(50, STANDING.None)]
        [DataRow(51, STANDING.Remedial)]
        [DataRow(80, STANDING.Remedial)]
        [DataRow(81, STANDING.Average)]
        [DataRow(95, STANDING.Average)]
        [DataRow(96, STANDING.SumaCumLaude)]
        [DataRow(int.MaxValue, STANDING.SumaCumLaude)]
        public void Can_Detect_Grade_Standings(int mark, STANDING standing)
        {
            // Arrange
            Diploma diploma = new() { Id = 100, Credits = 1, Requirements = new[] { 100 } };
            Student student = new() { Id = 1, Courses = new Course[] { new() { Id = 1, Mark = mark } } };
            var repository = new Mock<IRepository>();
            repository.Setup(static _ => _.GetRequirements(It.IsAny<int[]>()))
                .Returns(new List<Requirement> { new() { Id = 100, Credits = 1, Courses = new[] { 1 } } });

            // Act
            var result = new GraduationTracker(repository.Object).HasGraduated(diploma, student);

            // Assert
            Assert.AreEqual(standing, result.Standing);
        }

        [DataTestMethod]
        [DataRow(0, true)]
        [DataRow(1, true)]
        [DataRow(2, false)]
        public void Can_Detect_Grade_Graduated(int credits, bool hasDiploma)
        {
            // Arrange
            Diploma diploma = new() { Id = 100, Credits = credits, Requirements = new[] { 100 } };

            Student student = new()
            {
                Id = 1,
                Courses = new Course[] { new() { Id = 1, Mark = 50 } }
            };
            var repository = new Mock<IRepository>();
            repository.Setup(static _ => _.GetRequirements(It.IsAny<int[]>()))
                .Returns(new List<Requirement> { new() { Id = 100, Credits = 1, Courses = new[] { 1 } } });
            // Act
            var result = new GraduationTracker(repository.Object).HasGraduated(diploma, student);

            // Assert
            Assert.AreEqual(hasDiploma, result.HasDiplomaCreditCount);
        }



    }
}
