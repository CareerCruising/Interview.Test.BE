using System.Linq;
using GraduationTracker.Repositories;
using GraduationTracker.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraduationTracker.Tests.Unit
{
    [TestClass()]
    public class DiplomaServiceTests
    {
        [TestMethod()]
        [Description("Test if returns non empty list of requirements for given diploma")]
        public void GetRequirementsTest()
        {
            // Arrange 
            var diplomaRepository = new DiplomaRepository();
            var diploma = diplomaRepository.GetById(1);
            var diplomaService = new DiplomaService(diploma, new RequirementRepository());

            // Act 
            var actual = diplomaService.GetRequirements();

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Any());
        }
    }
}