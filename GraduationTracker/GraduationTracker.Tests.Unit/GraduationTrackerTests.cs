using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Moq;
using GraduationTracker.Contract.DataContract;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        //used Moq for mocking repositories
        private Mock<IRequirementRepository> _mockRequirementRepository;
        private Mock<IDiplomaRepository> _mockDiplomaRepository;
        private Mock<IStudentRepository> _mockStudentRepository;
        private GraduationTracker _tracker;
        private List<Requirement> _requirements;

        [TestInitialize]
        public void Init()
        {
            _mockRequirementRepository = new Mock<IRequirementRepository>();
            _mockDiplomaRepository = new Mock<IDiplomaRepository>();
            _mockStudentRepository = new Mock<IStudentRepository>();

            _tracker = new GraduationTracker(_mockRequirementRepository.Object, _mockDiplomaRepository.Object, _mockStudentRepository.Object);

            _requirements = new List<Requirement>
                    {
                    new Requirement{Id = 100, Name = "Math", MinimumMark=50, Courses = new Course[]{ new Course { Id = 1 } }, Credits=1 },
                    new Requirement{Id = 102, Name = "Science", MinimumMark=50, Courses = new Course[]{ new Course { Id = 2 } }, Credits=1 },
                    new Requirement{Id = 103, Name = "Literature", MinimumMark=50, Courses = new Course[]{ new Course { Id = 3 } }, Credits=1},
                    new Requirement{Id = 104, Name = "Physichal Education", MinimumMark=50, Courses = new Course[]{ new Course { Id = 4 } }, Credits=1 }
                };


            //setup mocked requirement repository
            _mockRequirementRepository.Setup(x => x.GetRequirements()).Returns(_requirements);
            _mockRequirementRepository.Setup(r => r.GetRequirement(It.IsAny<int>()))
                   .Returns<int>(id => _requirements.SingleOrDefault(r => r.Id == id));

            var diplomas = new[]
            {
                new Diploma
                {
                    Id = 1,
                    Credits = 4,
                    Requirements = new Requirement[]
                    {
                        new Requirement { Id = 100 },
                        new Requirement { Id = 102 },
                        new Requirement { Id = 103 },
                        new Requirement { Id = 104 }
                    }
                }
            };

            //setup mocked diploma repository
            _mockDiplomaRepository.Setup(x => x.GetDiplomas()).Returns(diplomas);
            _mockDiplomaRepository.Setup(r => r.GetDiploma(It.IsAny<int>()))
                  .Returns<int>(id => diplomas.SingleOrDefault(r => r.Id == id));

            var students = new[]
            {
               new Student
               {
                   Id = 1,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 3, Name = "Literature", Mark=95 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=95 }
                   }
               },
               new Student
               {
                   Id = 2,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=80 },
                        new Course{Id = 2, Name = "Science", Mark=80 },
                        new Course{Id = 3, Name = "Literature", Mark=80 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=80 }
                   }
               },
            new Student
            {
                Id = 3,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=50 },
                    new Course{Id = 2, Name = "Science", Mark=50 },
                    new Course{Id = 3, Name = "Literature", Mark=50 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=50 }
                }
            },
            new Student
            {
                Id = 4,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=40 },
                    new Course{Id = 2, Name = "Science", Mark=40 },
                    new Course{Id = 3, Name = "Literature", Mark=40 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=40 }
                }
            }



        };

            //setup mocked student repository
            _mockStudentRepository.Setup(x => x.GetStudents()).Returns(students);
            _mockStudentRepository.Setup(r => r.GetStudent(It.IsAny<int>()))
                     .Returns<int>(id => students.SingleOrDefault(r => r.Id == id));


        }




        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(1, 2)]
        public void TestHasGraduated(int diplomaId, int studentId)
        {


            var graduated = new List<Tuple<bool, STANDING, bool>>();
            graduated.Add(_tracker.HasGraduated(diplomaId, studentId));
            Assert.IsTrue(graduated.Any());

        }

        [DataTestMethod]
        [DataRow(95)]
        public void TestHasGraduated_MarksAboveAverage(int marks)
        {

            var students = new[] { new Student
            {
                Id = 1,
                Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark=marks },
                        new Course{Id = 2, Name = "Science", Mark=marks},
                        new Course{Id = 3, Name = "Literature", Mark=marks },
                        new Course{Id = 4, Name = "Physichal Education", Mark=marks }
                    }
            } };

            Mock<IStudentRepository> _mockStuRepository = new Mock<IStudentRepository>();
            _mockStuRepository.Setup(x => x.GetStudents()).Returns(students);
            _mockStuRepository.Setup(r => r.GetStudent(It.IsAny<int>()))
                     .Returns<int>(id => students.SingleOrDefault(r => r.Id == id));
            var tracker = new GraduationTracker(_mockRequirementRepository.Object, _mockDiplomaRepository.Object, _mockStuRepository.Object);

            var result = tracker.HasGraduated(1, 1);
            Assert.IsTrue(result.Item1); //should return true if graduated

        }

        [DataTestMethod]
        [DataRow(30)]
        public void TestHasGraduated_MarksBelowAverage(int marks)
        {

            var students = new[] { new Student
            {
                Id = 1,
                Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark=marks },
                        new Course{Id = 2, Name = "Science", Mark=marks},
                        new Course{Id = 3, Name = "Literature", Mark=marks },
                        new Course{Id = 4, Name = "Physichal Education", Mark=marks }
                    }
            } };

            Mock<IStudentRepository> _mockStuRepository = new Mock<IStudentRepository>();
            _mockStuRepository.Setup(x => x.GetStudents()).Returns(students);
            _mockStuRepository.Setup(r => r.GetStudent(It.IsAny<int>()))
                     .Returns<int>(id => students.SingleOrDefault(r => r.Id == id));
            var tracker = new GraduationTracker(_mockRequirementRepository.Object, _mockDiplomaRepository.Object, _mockStuRepository.Object);

            var result = tracker.HasGraduated(1, 1);
            Assert.IsFalse(result.Item1);//should return false if not graduated

        }



        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(1, 2)]
        public void TestHasCredits(int diplomaId, int studentId)
        {
            var graduated = new List<Tuple<bool, STANDING, bool>>();
            graduated.Add(_tracker.HasGraduated(diplomaId, studentId));
            Assert.IsTrue(graduated.Any(x => x.Item3)); //should return true if has credit

        }

        [DataTestMethod]
        [DataRow(1, 3)]
        [DataRow(1, 4)]
        public void TestNoCredits(int diplomaId, int studentId)
        {
            var graduated = new List<Tuple<bool, STANDING, bool>>();
            graduated.Add(_tracker.HasGraduated(diplomaId, studentId));
            Assert.IsFalse(graduated.Any(x => x.Item3)); //should return false if no credit

        }

        [TestMethod]
        [DataRow(40, STANDING.Remedial)]
        [DataRow(50, STANDING.Average)]
        [DataRow(80, STANDING.MagnaCumLaude)]
        public void TestStanding(int marks, STANDING standing)
        {
            var students = new[]
            {
               new Student
               {
                   Id = 1,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=marks},
                        new Course{Id = 2, Name = "Science", Mark=marks },
                        new Course{Id = 3, Name = "Literature", Mark=marks },
                        new Course{Id = 4, Name = "Physichal Education", Mark=marks }
                   }
               } };
            Mock<IStudentRepository> _mockStuRepository = new Mock<IStudentRepository>();
            _mockStuRepository.Setup(x => x.GetStudents()).Returns(students);
            _mockStuRepository.Setup(r => r.GetStudent(It.IsAny<int>()))
                     .Returns<int>(id => students.SingleOrDefault(r => r.Id == id));
            var tracker = new GraduationTracker(_mockRequirementRepository.Object, _mockDiplomaRepository.Object, _mockStuRepository.Object);

            var result = tracker.HasGraduated(1, 1);
            Assert.AreEqual(standing, result.Item2);
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ThrowExceptionForWrongStudentId()
        {
            _tracker.HasGraduated(1, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ThrowExceptionForWrongDiplomaId()
        {
            _tracker.HasGraduated(2, 1);
        }



    }
}
