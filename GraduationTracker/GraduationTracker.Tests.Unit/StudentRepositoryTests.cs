using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests
{
    [TestClass()]
    public class StudentRepositoryTests
    {
        protected StudentRepository studentRepository { get; set; }

        public StudentRepositoryTests()
        {
            RepositoryFactoryBase.RepositoryFactoryName = "RepositoryFactory";
            RepositoryFactoryBase.RepositoryFactoryNamespace = "GraduationTracker";
            RepositoryFactoryBase.Refresh();

            DiplomaRepository diplomaRepository = new DiplomaRepository();
            Diploma diploma = diplomaRepository.GetDiploma().FirstOrDefault();

            this.studentRepository = new StudentRepository(diploma);
        }

        [TestMethod()]
        public void StudentRepositoryTest()
        {
            DiplomaRepository diplomaRepository = new DiplomaRepository();
            Diploma diploma = diplomaRepository.GetDiploma().FirstOrDefault();

            this.studentRepository = new StudentRepository(diploma);

            Assert.IsTrue(this.studentRepository != null);
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void AddTest()
        {
            DiplomaRepository diplomaRepository = new DiplomaRepository();
            Diploma diploma = diplomaRepository.GetDiploma().FirstOrDefault();

            this.studentRepository.Add(new Student(diploma, 5));
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void UpdateTest()
        {
            DiplomaRepository diplomaRepository = new DiplomaRepository();
            Diploma diploma = diplomaRepository.GetDiploma().FirstOrDefault();

            this.studentRepository.Update(new Student(diploma, 4));
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void DeleteTest()
        {
            this.studentRepository.Delete(4);
        }

        [TestMethod()]
        public void GetStudentTest()
        {
            IEnumerable<Student> students = this.studentRepository.GetStudent();
            
            Assert.IsTrue(students.Count() == 4);
        }

        [TestMethod()]
        public void GetStudentTest2()
        {
            Student student = this.studentRepository.GetStudent(2);

            Assert.IsTrue(student.Id == 2);
            Assert.IsTrue(student.CourseCount == 4);
        }
    }
}