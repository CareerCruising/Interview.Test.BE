using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests
{
    [TestClass()]
    public class StudentCourseRepositoryTests
    {
        protected StudentCourseRepository studentCourseRepository { get; set; }

        public StudentCourseRepositoryTests()
        {
            RepositoryFactoryBase.RepositoryFactoryName = "RepositoryFactory";
            RepositoryFactoryBase.RepositoryFactoryNamespace = "GraduationTracker";
            RepositoryFactoryBase.Refresh();

            this.studentCourseRepository = new StudentCourseRepository();
        }

        [TestMethod()]
        public void StudentCourseRepositoryTest()
        {
            this.studentCourseRepository = new StudentCourseRepository();

            Assert.IsTrue(this.studentCourseRepository != null);
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void AddTest()
        {
            this.studentCourseRepository.Add(new StudentCourse() { Id = 5, StudentId = 5, CourseId = 4, Mark = 35 });
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void UpdateTest()
        {
            this.studentCourseRepository.Add(new StudentCourse() { Id = 3, StudentId = 3, CourseId = 1, Mark = 60 });
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void DeleteTest()
        {
            this.studentCourseRepository.Delete(7);
        }

        [TestMethod()]
        public void GetStudentCourseTest()
        {
            IEnumerable<StudentCourse> studentCourses = this.studentCourseRepository.GetStudentCourse();

            Assert.IsTrue(studentCourses.Count() == 16);
        }

        [TestMethod()]
        public void GetStudentCourseTest1()
        {
            IEnumerable<StudentCourse> studentCourses = this.studentCourseRepository.GetStudentCourse(2);

            Assert.IsTrue(studentCourses.Count() == 4);
        }
    }
}