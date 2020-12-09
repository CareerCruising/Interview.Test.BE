using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        [TestMethod]
        public void TestHasGraduated()
        {
            var students = new[]
            {
               Repository.GetStudent(1),
               Repository.GetStudent(2),
               Repository.GetStudent(3),
               Repository.GetStudent(4),
            };

            Assert.IsTrue(students.Where(student =>
                new GraduationTracker().HasGraduated(Repository.GetDiploma(1), student).Item1 == true).Count() == 3);
        }

        [TestMethod]
        public void TestHasRequiredCredits()
        {
            var student = new Student
            {
                Id = 2,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=80 },
                    new Course{Id = 2, Name = "Science", Mark=80 },
                    new Course{Id = 3, Name = "Literature", Mark=80 },
                }
            };

            Assert.IsTrue(new GraduationTracker().HasGraduated(Repository.GetDiploma(1), student).Item1 == false);
        }

        [TestMethod]
        public void TestRequirementDifferentCourseID()
        {
            var student = Repository.GetStudent(2);
            student.Courses.First().Id = 5;

            Assert.IsTrue(new GraduationTracker().HasGraduated(Repository.GetDiploma(1), student).Item1 == false);
        }

        [TestMethod]
        public void TestNegativeCourseMark()
        {
            var student = Repository.GetStudent(2);
            student.Courses.First().Mark = -80;

            Assert.IsTrue(new GraduationTracker().HasGraduated(Repository.GetDiploma(1), student) == null);
        }

        [TestMethod]
        public void TestNegativeCourseCredit()
        {
            //Course Credits property is currently not implemented
            //if it were implemented this value would be used to check HasGraduated instead of +=1
            //when tallying credits, allowing for different courses to carry different weights
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void TestNegativeDiplomaCredits()
        {
            var diploma = Repository.GetDiploma(1);
            diploma.Credits = -4;

            Assert.IsTrue(new GraduationTracker().HasGraduated(diploma, Repository.GetStudent(2)) == null);
        }
    }
}
