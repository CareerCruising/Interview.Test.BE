using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraduationTracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker.Tests
{
    [TestClass()]
    public class RequirementRepositoryTests
    {
        protected RequirementRepository requirementRepository { get; set; }

        public RequirementRepositoryTests()
        {
            RepositoryFactoryBase.RepositoryFactoryName = "RepositoryFactory";
            RepositoryFactoryBase.RepositoryFactoryNamespace = "GraduationTracker";
            RepositoryFactoryBase.Refresh();

            this.requirementRepository = new RequirementRepository();
        }

        [TestMethod()]
        public void RequirementRepositoryTest()
        {
            this.requirementRepository = new RequirementRepository();
            
            Assert.IsTrue(this.requirementRepository != null);
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void AddTest()
        {
            this.requirementRepository.Add(new Requirement(1) { Name = "Science", MinimumMark = 50 });
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void UpdateTest()
        {
            this.requirementRepository.Add(new Requirement(1) { Name = "Science", MinimumMark = 50 });
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void DeleteTest()
        {
            this.requirementRepository.Delete(1);
        }

        [TestMethod()]
        public void GetRequirementTest()
        {
            IEnumerable<Requirement> requirements = this.requirementRepository.GetRequirement();

            Assert.IsTrue(requirements.Count() == 4);
        }

        [TestMethod()]
        public void GetCoursesByRequirementTest()
        {
            IEnumerable<Course> courses = this.requirementRepository.GetCoursesByRequirement(100);

            Assert.IsTrue(courses.Count() == 1);
            Assert.IsTrue(courses.FirstOrDefault().Name == "Math" && courses.FirstOrDefault().Credits == 1);
        }

        [TestMethod()]
        public void GetRequirementTest1()
        {
            Requirement requirement = this.requirementRepository.GetRequirement(100);

            Assert.IsTrue(requirement.Name == "Math" && requirement.MinimumMark == 50 );
        }
    }
}