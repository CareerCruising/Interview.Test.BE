using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests
{
    [TestClass()]
    public class CourseRepositoryTests
    {
        protected CourseRepository courseRepository { get; set; }

        public CourseRepositoryTests()
        {
            this.courseRepository = new CourseRepository();
        }

        [TestMethod()]
        public void CourseRepositoryTest()
        {
            this.courseRepository = new CourseRepository();
            
            Assert.IsTrue(this.courseRepository != null);
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void AddTest()
        {
            this.courseRepository.Add(new Course() { Id = 1, Name = "Physics", Credits = 1 });
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void UpdateTest()
        {
            this.courseRepository.Add(new Course() { Id = 2, Name = "Chemistry", Credits = 2 });
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void DeleteTest()
        {
            this.courseRepository.Delete(1);
        }

        [TestMethod()]
        public void GetCourseTest()
        {
            IEnumerable<Course> courses = this.courseRepository.GetCourse();

            Assert.IsTrue(courses.Count() == 4);
        }

        [TestMethod()]
        public void GetCourseTest1()
        {
            Course course = this.courseRepository.GetCourse(3);

            Assert.IsTrue(course.Name == "Literature" && course.Credits == 1);
        }
    }
}