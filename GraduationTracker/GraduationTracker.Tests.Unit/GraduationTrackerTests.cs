using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeItEasy;
using GraduationTracker.Abstraction;
using GraduationTracker.Models;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        private IRequirementsRepository _requirementsRepository;
        private IDiplomasRepository _diplomasRepository;
        private IStudentsRepository _studentRepository;

        [TestInitialize]
        public void Init()
        {
            var requirements = new List<Requirement>
            {
                new Requirement {Id = 100, Name = "Math", MinimumMark = 50, Courses = new int[] {1}, Credits = 1},
                new Requirement {Id = 102, Name = "Science", MinimumMark = 50, Courses = new int[] {2}, Credits = 1},
                new Requirement {Id = 103, Name = "Literature", MinimumMark = 50, Courses = new int[] {3}, Credits = 1},
                new Requirement {Id = 104, Name = "Physical Education", MinimumMark = 50, Courses = new int[] {4}, Credits = 1}
            };

            _requirementsRepository = A.Fake<IRequirementsRepository>();
            _diplomasRepository = A.Fake<IDiplomasRepository>();
            _studentRepository = A.Fake<IStudentsRepository>();

            A.CallTo(() => _studentRepository.GetStudent(A<int>.Ignored))
                .Returns(new Student
                {
                    Id = 1,
                    Courses = new[]
                    {
                        new Course {Id = 1, Name = "Math", Mark = 50},
                        new Course {Id = 2, Name = "Science", Mark = 50},
                        new Course {Id = 3, Name = "Literature", Mark = 50},
                        new Course {Id = 4, Name = "Physical Education", Mark = 50}
                    }
                });

            A.CallTo(() => _requirementsRepository.GetRequirements()).Returns(requirements);
            A.CallTo(() => _requirementsRepository.GetRequirement(A<int>.Ignored)).ReturnsLazily((int id) => requirements.FirstOrDefault(x => x.Id == id));
            A.CallTo(() => _diplomasRepository.GetDiploma(A<int>.Ignored))
                .Returns(new Diploma
                {
                    Id = 1,
                    Credits = 4,
                    Requirements = new int[] { 100, 102, 103, 104 }
                });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Tracker_ShouldThrowExceptionIfRequirementsRepositoryIsNull()
        {
            var tracker = new GraduationTracker(A.Fake<IStudentsRepository>(), null, A.Fake<IDiplomasRepository>());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Tracker_ShouldThrowExceptionIfStudentsRepositoryIsNull()
        {
            var tracker = new GraduationTracker(null, A.Fake<IRequirementsRepository>(), A.Fake<IDiplomasRepository>());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Tracker_ShouldThrowExceptionIfDiplomasRepositoryIsNull()
        {
            var tracker = new GraduationTracker(A.Fake<IStudentsRepository>(), A.Fake<IRequirementsRepository>(), null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void HasGraduated_ShouldThrowExceptionIfStudentDoesNotExist()
        {
            //Arrange
            var studentRepository = A.Fake<IStudentsRepository>();

            A.CallTo(() => studentRepository.GetStudent(A<int>.Ignored)).Returns(null);

            //Act
            var tracker = new GraduationTracker(studentRepository, _requirementsRepository, _diplomasRepository);
            tracker.HasGraduated(1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void HasGraduated_ShouldThrowExceptionIfDiplomaDoesNotExist()
        {
            //Arrange
            var diplomasRepository = A.Fake<IDiplomasRepository>();
            A.CallTo(() => diplomasRepository.GetDiploma(A<int>.Ignored)).Returns(null);

            //Act
            var tracker = new GraduationTracker(_studentRepository, _requirementsRepository, diplomasRepository);
            tracker.HasGraduated(1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void HasGraduated_ShouldThrowExceptionIfRequirementDoesNotExist()
        {
            //Arrange
            var requirementRepository = A.Fake<IRequirementsRepository>();
            A.CallTo(() => requirementRepository.GetRequirement(A<int>.Ignored)).Returns(null);

            //Act
            var tracker = new GraduationTracker(_studentRepository, requirementRepository, _diplomasRepository);
            tracker.HasGraduated(1, 1);
        }

        [DataRow(95)]
        [DataRow(80)]
        [DataRow(50)]
        [DataTestMethod]
        public void HasGraduated_ShouldReturnSuccessfulResultIfMarksAreAboveAverage (int mark)
        {
            //Arrange
            var studentRepository = A.Fake<IStudentsRepository>();

            A.CallTo(() => studentRepository.GetStudent(A<int>.Ignored))
                .Returns(new Student
                {
                    Id = 1,
                    Courses = new[]
                    {
                        new Course {Id = 1, Name = "Math", Mark = mark},
                        new Course {Id = 2, Name = "Science", Mark = mark},
                        new Course {Id = 3, Name = "Literature", Mark = mark},
                        new Course {Id = 4, Name = "Physical Education", Mark = mark}
                    }
                });

            var tracker = new GraduationTracker(studentRepository, _requirementsRepository, _diplomasRepository);

            //Act
            var result = tracker.HasGraduated(1, 1);

            //Assert
            Assert.IsTrue(result.IsGraduated);
        }

        [DataRow(40)]
        [DataTestMethod]
        public void HasGraduated_ShouldReturnFailureResultIfMarksAreBelowAverage(int mark)
        {
            //Arrange
            var studentRepository = A.Fake<IStudentsRepository>();

            A.CallTo(() => studentRepository.GetStudent(A<int>.Ignored))
                .Returns(new Student
                {
                    Id = 1,
                    Courses = new[]
                    {
                        new Course {Id = 1, Name = "Math", Mark = mark},
                        new Course {Id = 2, Name = "Science", Mark = mark},
                        new Course {Id = 3, Name = "Literature", Mark = mark},
                        new Course {Id = 4, Name = "Physical Education", Mark = mark}
                    }
                });

            var tracker = new GraduationTracker(studentRepository, _requirementsRepository, _diplomasRepository);

            //Act
            var result = tracker.HasGraduated(1, 1);

            //Assert
            Assert.IsFalse(result.IsGraduated);
        }

        [TestMethod]
        public void HasGraduated_ShouldCallStudentsRepositoryOnce()
        {
            var tracker = new GraduationTracker(_studentRepository, _requirementsRepository, _diplomasRepository);

            //Act
            tracker.HasGraduated(1, 1);

            //Assert
            A.CallTo(() => _studentRepository.GetStudent(A<int>.Ignored)).MustHaveHappenedOnceExactly();
        }

        [TestMethod]
        public void HasGraduated_ShouldCallDiplomasRepositoryOnce()
        {
            var tracker = new GraduationTracker(_studentRepository, _requirementsRepository, _diplomasRepository);

            //Act
            tracker.HasGraduated(1, 1);

            //Assert
            A.CallTo(() => _diplomasRepository.GetDiploma(A<int>.Ignored)).MustHaveHappenedOnceExactly();
        }

        [TestMethod]
        public void HasGraduated_ShouldCallRequirementsRepositoryAsManyTimesAsDiplomaRequirements()
        {
            //Assert
            var diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] {100, 102, 103, 104}
            };

            var diplomasRepository = A.Fake<IDiplomasRepository>();
            A.CallTo(() => diplomasRepository.GetDiploma(A<int>.Ignored))
                .Returns(diploma);

            var tracker = new GraduationTracker(_studentRepository, _requirementsRepository, diplomasRepository);

            //Act
            tracker.HasGraduated(1, 1);

            //Assert
            A.CallTo(() => _requirementsRepository.GetRequirement(A<int>.Ignored)).MustHaveHappenedANumberOfTimesMatching(x => x == diploma.Requirements.Length);
        }

        [DataRow(95, Standing.SummaCumLaude)]
        [DataRow(80, Standing.MagnaCumLaude)]
        [DataRow(50, Standing.Average)]
        [DataRow(40, Standing.Remedial)]
        [DataTestMethod]
        public void HasGraduated_ShouldReturnCorrectStanding(int mark, Standing expectedStanding)
        {
            //Arrange
            var studentRepository = A.Fake<IStudentsRepository>();

            A.CallTo(() => studentRepository.GetStudent(A<int>.Ignored))
                .Returns(new Student
                {
                    Id = 1,
                    Courses = new[]
                    {
                        new Course {Id = 1, Name = "Math", Mark = mark},
                        new Course {Id = 2, Name = "Science", Mark = mark},
                        new Course {Id = 3, Name = "Literature", Mark = mark},
                        new Course {Id = 4, Name = "Physical Education", Mark = mark}
                    }
                });

            var tracker = new GraduationTracker(studentRepository, _requirementsRepository, _diplomasRepository);

            //Act
            var result = tracker.HasGraduated(1, 1);

            //Assert
            Assert.AreEqual(expectedStanding, result.Standing);
        }

        [TestMethod]
        public void HasGraduated_ShouldReturnCalculatedCreditsIfRequirementsMatched()
        {
            //Arrange
            var requirements = new List<Requirement>
            {
                new Requirement {Id = 100, Name = "Math", MinimumMark = 50, Courses = new int[] {1}, Credits = 1}, //Passed
                new Requirement {Id = 102, Name = "Science", MinimumMark = 50, Courses = new int[] {2}, Credits = 1}, //Passed
                new Requirement {Id = 103, Name = "Literature", MinimumMark = 80, Courses = new int[] {3}, Credits = 1}, //Passed
                new Requirement {Id = 104, Name = "Physical Education", MinimumMark = 90, Courses = new int[] {4}, Credits = 1} //Failed (90 > 80)
            };

            var requirementRepository = A.Fake<IRequirementsRepository>();
            var studentRepository = A.Fake<IStudentsRepository>();

            A.CallTo(() => requirementRepository.GetRequirement(A<int>.Ignored)).ReturnsLazily((int id) => requirements.FirstOrDefault(x => x.Id == id));
            A.CallTo(() => studentRepository.GetStudent(A<int>.Ignored))
                .Returns(new Student
                {
                    Id = 1,
                    Courses = new[]
                    {
                        new Course {Id = 1, Name = "Math", Mark = 80},
                        new Course {Id = 2, Name = "Science", Mark = 80},
                        new Course {Id = 3, Name = "Literature", Mark = 80},
                        new Course {Id = 4, Name = "Physical Education", Mark = 80}
                    }
                });

            var tracker = new GraduationTracker(studentRepository, requirementRepository, _diplomasRepository);

            //Act
            var result = tracker.HasGraduated(1, 1);

            //Assert
            Assert.AreEqual(3, result.Credits);
        }
    }
}