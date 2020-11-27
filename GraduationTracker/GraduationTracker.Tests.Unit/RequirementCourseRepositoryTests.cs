using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests
{
    [TestClass()]
    public class RequirementCourseRepositoryTests
    {
        protected RequirementCourseRepository requirementCourseRepository { get; set; }

        public RequirementCourseRepositoryTests()
        {
            RepositoryFactoryBase.RepositoryFactoryName = "RepositoryFactory";
            RepositoryFactoryBase.RepositoryFactoryNamespace = "GraduationTracker";
            RepositoryFactoryBase.Refresh();

            this.requirementCourseRepository = new RequirementCourseRepository();
        }

        [TestMethod()]
        public void RequirementCourseRepositoryTest()
        {
            this.requirementCourseRepository = new RequirementCourseRepository();

            Assert.IsTrue(this.requirementCourseRepository != null);
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void AddTest()
        {
            this.requirementCourseRepository.Add(new RequirementCourse() { Id = 5, RequirementId = 105, CourseId = 5 });
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void UpdateTest()
        {
            this.requirementCourseRepository.Add(new RequirementCourse() { Id = 4, RequirementId = 104, CourseId = 4 });
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void DeleteTest()
        {
            this.requirementCourseRepository.Delete(4);
        }

        [TestMethod()]
        public void GetRequirementCoursesTest()
        {
            IEnumerable<RequirementCourse> requirementCourse = this.requirementCourseRepository.GetRequirementCourses(103);

            Assert.IsTrue(requirementCourse.Count() == 1);
            Assert.IsTrue(requirementCourse.FirstOrDefault().CourseId == 3 && requirementCourse.FirstOrDefault().Id == 3);
        }

        [TestMethod()]
        public void GetRequirementCourseTest()
        {
            IEnumerable<RequirementCourse> requirementCourse = this.requirementCourseRepository.GetRequirementCourse();
            
            Assert.IsTrue(requirementCourse.Count() == 4);
        }

        [TestMethod()]
        public void GetRequirementCourseTest1()
        {
            RequirementCourse requirementCourse = this.requirementCourseRepository.GetRequirementCourse(1);
            
            Assert.IsTrue(requirementCourse.RequirementId == 100 && requirementCourse.CourseId == 1);
        }
    }
}