using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests
{
    [TestClass()]
    public class DiplomaRequirementRepositoryTests
    {
        protected DiplomaRequirementRepository diplomaRequirementRepository { get; set; }

        public DiplomaRequirementRepositoryTests()
        {
            this.diplomaRequirementRepository = new DiplomaRequirementRepository();
        }

        [TestMethod()]
        public void DiplomaRequirementRepositoryTest()
        {
            this.diplomaRequirementRepository = new DiplomaRequirementRepository();
            
            Assert.IsTrue(this.diplomaRequirementRepository != null);
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void AddTest()
        {
            this.diplomaRequirementRepository.Add(new DiplomaRequirement() { Id = 5, DiplomaId = 1, RequirementId = 104 });
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void UpdateTest()
        {
            this.diplomaRequirementRepository.Update(new DiplomaRequirement() { Id = 4, DiplomaId = 1, RequirementId = 103 });
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void DeleteTest()
        {
            this.diplomaRequirementRepository.Delete(2);
        }

        [TestMethod()]
        public void GetRequirementByDiplomaTest()
        {
            IEnumerable<DiplomaRequirement> diplomaRequirements = this.diplomaRequirementRepository.GetRequirementByDiploma(1);

            Assert.IsNotNull(diplomaRequirements);
            Assert.IsTrue(diplomaRequirements.Count() == 4);
        }

        [TestMethod()]
        public void GetRequirementsByDiplomaIdTest()
        {
            IEnumerable<Requirement> requirements = this.diplomaRequirementRepository.GetRequirementsByDiplomaId(1);

            Assert.IsNotNull(requirements);
            Assert.IsTrue(requirements.Count() == 4);
        }

        [TestMethod()]
        public void GetDiplomaRequirementTest()
        {
            IEnumerable<DiplomaRequirement> diplomaRequirements = this.diplomaRequirementRepository.GetDiplomaRequirement();

            Assert.IsTrue(diplomaRequirements.Count() == 4);
        }

        [TestMethod()]
        public void GetDiplomaRequirementTest1()
        {
            DiplomaRequirement diplomaRequirement = this.diplomaRequirementRepository.GetDiplomaRequirement(3);

            Assert.IsNotNull(diplomaRequirement);
            Assert.IsTrue(diplomaRequirement.DiplomaId == 1 && diplomaRequirement.RequirementId == 103);
        }
    }
}