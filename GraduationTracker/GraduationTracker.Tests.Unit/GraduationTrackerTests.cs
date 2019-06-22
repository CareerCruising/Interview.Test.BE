using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using GraduationTracker.Models;
using GraduationTracker.Repositories;
using GraduationTracker.Services;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        private readonly GraduationService tracker = new GraduationService();
        private readonly StudentRepository studentRepository = new StudentRepository();
        private readonly DiplomaRepository diplomaRepository = new DiplomaRepository();
        private readonly RequirementRepository requirementRepository = new RequirementRepository();

        [TestMethod]
        public void TestStudentShouldGraduate()
        {
            var diploma = diplomaRepository.GetItem(1);

            //Repository Data
            var students = new List<Student>()
            {
                studentRepository.GetItem(1),
                studentRepository.GetItem(2),
                studentRepository.GetItem(3),
                studentRepository.GetItem(4) //Mark 40: will not Graduate
            };

            var graduated = students.Where(x => tracker.HasGraduated(diploma, x).Passed);

            Assert.AreEqual(graduated.Count(), 3);

            //Custom Data
            var newStudent = new Student
            {
                Id = 5,
                Courses = new Course[]
                  {
                      new Course{Id = 1, Name = "Math", Mark=5000 },
                      new Course{Id = 2, Name = "Science", Mark= -1 },
                      new Course{Id = 3, Name = "Literature", Mark=2 },
                      new Course{Id = 4, Name = "Physichal Education", Mark=99 }
                  }
            };

            var newStudentResult = tracker.HasGraduated(diploma, newStudent);
            Assert.IsTrue(newStudentResult.Passed);
        }

        [TestMethod]
        public void TestStudentShouldNotGraduate()
        {
            var diploma = diplomaRepository.GetItem(1);

            //Repository Data
            var student = studentRepository.GetItem(4);

            var result = tracker.HasGraduated(diploma, student);

            Assert.IsFalse(result.Passed);
            Assert.IsTrue(result.Status == Standing.Remedial);

            //Custom Data
            var newStudent = new Student
            {
                Id = 1,
                Courses = new Course[]
                  {
                      new Course{Id = 1, Name = "Math", Mark=0 },
                      new Course{Id = 2, Name = "Science", Mark=100 },
                      new Course{Id = 3, Name = "Literature", Mark=1 },
                      new Course{Id = 4, Name = "Physichal Education", Mark=2 }
                  }
            };

            var newStudentResult = tracker.HasGraduated(diploma, newStudent);
            Assert.IsFalse(newStudentResult.Passed);
        }

        [TestMethod]
        public void TestStudentCredits()
        {
            var diploma = diplomaRepository.GetItem(1);

            var newStudent = new Student
            {
                Id = 1,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=0 },         // Below MinimumMark
                    new Course{Id = 2, Name = "Science", Mark=49},      // Below MinimumMark
                    new Course{Id = 3, Name = "Literature", Mark= 50},
                    new Course{Id = 4, Name = "Physichal Education", Mark=51 }
                }
            };

            var result = tracker.HasGraduated(diploma, newStudent);

            Assert.AreEqual(newStudent.Courses[0].Credits, 0);
            Assert.AreEqual(newStudent.Courses[1].Credits, 0);
            Assert.AreEqual(newStudent.Courses[2].Credits, 1);
            Assert.AreEqual(newStudent.Courses[3].Credits, 1);
        }
    }
}
