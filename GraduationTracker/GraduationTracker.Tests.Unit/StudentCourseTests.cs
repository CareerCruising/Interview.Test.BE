using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GraduationTracker.Tests
{
    [TestClass()]
    public class StudentCourseTests
    {
        public StudentCourseTests()
        {
            RepositoryFactoryBase.RepositoryFactoryName = "RepositoryFactory";
            RepositoryFactoryBase.RepositoryFactoryNamespace = "GraduationTracker";
            RepositoryFactoryBase.Refresh();
        }

        [TestMethod()]
        public void StudentCourseTest()
        {
            StudentCourse studentCourse = new StudentCourse()
            {
                Id = 1,
                StudentId = 1,
                CourseId = 1,
                Mark = 95
            };

            Assert.IsNotNull(studentCourse);
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void AddTest()
        {
            StudentCourse studentCourse = new StudentCourse()
            {
                Id = 17,
                StudentId = 4,
                CourseId = 3,
                Mark = 35
            };

            studentCourse.Add();
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void UpdateTest()
        {
            StudentCourse studentCourse = new StudentCourse()
            {
                Id = 16,
                StudentId = 4,
                CourseId = 4,
                Mark = 80
            };

            studentCourse.Update();
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void DeleteTest()
        {
            StudentCourse studentCourse = new StudentCourse()
            {
                Id = 16,
                StudentId = 4,
                CourseId = 4,
                Mark = 40
            };

            studentCourse.Delete();
        }

        [TestMethod()]
        public void IsCoursePassedFailedTest()
        {
            StudentCourse studentCourse = new StudentCourse()
            {
                Id = 16,
                StudentId = 4,
                CourseId = 4,
                Mark = 40
            };

            Assert.IsFalse(studentCourse.IsCoursePassed(50));
        }

        [TestMethod()]
        public void IsCoursePassedPassedTest()
        {
            StudentCourse studentCourse = new StudentCourse()
            {
                Id = 16,
                StudentId = 4,
                CourseId = 4,
                Mark = 80
            };

            Assert.IsTrue(studentCourse.IsCoursePassed(50));
        }
    }
}