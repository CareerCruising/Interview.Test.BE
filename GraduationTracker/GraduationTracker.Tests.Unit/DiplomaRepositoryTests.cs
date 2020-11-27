using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests
{
    [TestClass()]
    public class DiplomaRepositoryTests
    {
        protected DiplomaRepository diplomaRepository { get; set; }

        public DiplomaRepositoryTests()
        {
            RepositoryFactoryBase.RepositoryFactoryName = "RepositoryFactory";
            RepositoryFactoryBase.RepositoryFactoryNamespace = "GraduationTracker";
            RepositoryFactoryBase.Refresh();

            this.diplomaRepository = new DiplomaRepository();
        }

        [TestMethod()]
        public void DiplomaRepositoryTest()
        {
            this.diplomaRepository = new DiplomaRepository();

            Assert.IsNotNull(this.diplomaRepository);
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void AddTest()
        {
            this.diplomaRepository.Add(new Diploma(2));
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void UpdateTest()
        {
            this.diplomaRepository.Add(new Diploma(1));
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void DeleteTest()
        {
            this.diplomaRepository.Delete(1);
        }

        [TestMethod()]
        public void GetDiplomaTest()
        {
            IEnumerable<Diploma> diplomas = this.diplomaRepository.GetDiploma();

            Assert.IsNotNull(diplomas);
            Assert.IsTrue(diplomas.Count() == 1);
            Assert.IsTrue(diplomas.FirstOrDefault().Id == 1);
        }

        [TestMethod()]
        public void GetDiplomaTest1()
        {
            Diploma diploma = this.diplomaRepository.GetDiploma(1);

            Assert.IsNotNull(diploma);
            Assert.IsTrue(diploma.Id == 1);
        }
    }
}