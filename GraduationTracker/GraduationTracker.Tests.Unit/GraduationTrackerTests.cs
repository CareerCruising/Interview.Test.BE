using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using GraduationTracker.Repositories;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        private  Business_Logic.GraduationTracker GraduationTracker => new Business_Logic.GraduationTracker();

        private StudentRepository StudentRepository => new StudentRepository();
        private DiplomaRepository DiplomaRepository => new DiplomaRepository();

        [TestMethod]
        public void TestExistingStudentHasGraduated()
        {
            var diploma = DiplomaRepository.GetItem(1);

           
            var students = new List<Student>()
            {
                StudentRepository.GetItem(1),
                StudentRepository.GetItem(2),
                StudentRepository.GetItem(3),
                StudentRepository.GetItem(4) 
            };

            var graduated = students.Where(x => GraduationTracker.HasGraduated(diploma, x).Passed);

            Assert.AreEqual(graduated.Count(), 3);

          
          
        }

    
        [TestMethod]
        public void TestStudentHasNotGraduated()
        {
            var diploma = DiplomaRepository.GetItem(1);

            //Repository Data
            var student = StudentRepository.GetItem(4);

            var result = GraduationTracker.HasGraduated(diploma, student);

            Assert.IsFalse(result.Passed);
            Assert.IsTrue(result.Status == Standing.Remedial);

            //Custom Data
            var newStudent = new Student
            {
                Id = 1,
                Courses = new[]
                  {
                      new Course{Id = 1, Name = "Math", Mark=0 },
                      new Course{Id = 2, Name = "Science", Mark=100 },
                      new Course{Id = 3, Name = "Literature", Mark=1 },
                      new Course{Id = 4, Name = "Physical Education", Mark=2 }
                  }
            };

            var newStudentResult = GraduationTracker.HasGraduated(diploma, newStudent);
            Assert.IsFalse(newStudentResult.Passed);
        }

       
    }
}