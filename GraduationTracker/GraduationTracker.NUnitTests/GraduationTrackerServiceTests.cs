using GraduationTracker.Application.Services;
using GraduationTracker.Domain.Enums;
using GraduationTracker.Domain.Interfaces;
using GraduationTracker.Domain.Models;
using Moq;
using NUnit.Framework;

namespace GraduationTracker.NUnitTests
{
    public class GraduationTrackerServiceTests
    {
        private GraduationTrackerService _service;
        private Mock<IRequirementRepository> _requirementRepository;
        private Mock<ICourseRepository> _courseRepository;

        private Diploma _diploma;

        [SetUp]
        public void Setup()
        {
            _diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 1, 2, 3 , 4 }
            };

            _requirementRepository = new Mock<IRequirementRepository>();
            _requirementRepository.Setup(r => r.GetRequirement(It.IsAny<int>())).Returns(
                new Requirement { Id = 100, Name = "Math", MinimumMark = 50, Courses = new int[] { 1 }, Credits = 1 }
                );

            _courseRepository = new Mock<ICourseRepository>();
         
            _service = new GraduationTrackerService(_requirementRepository.Object, _courseRepository.Object);
        }

        [Test]
        [TestCase(95)]
        [TestCase(80)]
        [TestCase(50)]
        [TestCase(40)]
        public void GetAverage_FourCoursesWithMark_ReturnsAverage(int mark)
        {
            _courseRepository.Setup(r => r.GetCourseByStudent(It.IsAny<Student>(), It.IsAny<int>())).Returns(
             new Course { Id = 1, Name = "Math", Mark = mark }
             );

            var student = new Student
            {
                Id = 1,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=mark },
                    new Course{Id = 1, Name = "Math", Mark=mark },
                    new Course{Id = 1, Name = "Math", Mark=mark },
                    new Course{Id = 1, Name = "Math", Mark=mark }
                }
            };
            
            var result = _service.GetAverage(_diploma, student);

            Assert.That(mark, Is.EqualTo(result));
        }

        [Test]
        [TestCase(95)]
        [TestCase(50)]
        [TestCase(40)]
        public void IsPassed_MarkIsGreaterThan50_ReturnsTrue(int mark)
        {
            var result = _service.IsPassed(mark);

            Assert.That(mark >= 50, Is.EqualTo(result));
        }

        [Test]
        [TestCase(95, STANDING.SumaCumLaude)]
        [TestCase(80, STANDING.MagnaCumLaude)]
        [TestCase(50, STANDING.Average)]
        [TestCase(40, STANDING.Remedial)]
        public void GetStanding_OfMark_ReturnsCorrespondingStanding(int mark, STANDING expectedResult)
        {
            var result = _service.GetStanding(mark);

            Assert.That(expectedResult, Is.EqualTo(result));
        }
    }
}