using GraduationTracker.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationTracker.Tests.Unit
{
    /// <summary>
    /// Test the average calculation in StudentScoreCalculator
    /// </summary>
    [TestClass]
    public class StudentScoreCalculatorTest
    {
        static ScoreCalculatorTestData scoreCalculatorTestData;
        static RequirementDAO requirementDAO;

        [ClassInitialize]
        public static void InitializeTestData(TestContext testContext)
        {
            scoreCalculatorTestData = new ScoreCalculatorTestData();
            requirementDAO = new RequirementDAO(scoreCalculatorTestData);
        }

        [TestMethod]
        public void GetAverageMarksTest()
        {
            var scoreCalculator = new StudentScoreCalculator(requirementDAO);
            var actualResult = scoreCalculator.GetAverageMarks(scoreCalculatorTestData.Diplomas[0], scoreCalculatorTestData.Students[0]);
            var expectedResult = 89.5;
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void GetAverageMarksWithLessThanMinMarkReqTest()
        {
            var scoreCalculator = new StudentScoreCalculator(requirementDAO);
            var actualResult = scoreCalculator.GetAverageMarks(scoreCalculatorTestData.Diplomas[0], scoreCalculatorTestData.Students[1]);
            var expectedResult = 58;
            Assert.AreEqual(actualResult, expectedResult);
        }
    }

    class ScoreCalculatorTestData : IDatabase
    {
        public List<Student> Students => new List<Student>() {
            new Student()
            {
                Id = 1,
                Courses = new Course[] { 
                    new Course() { Id = 1, Mark = 85, Name = "Physics" },
                    new Course() { Id = 2, Mark = 98, Name = "Chemistry" },
                    new Course() { Id = 3, Mark = 100, Name = "Maths" },
                    new Course() { Id = 4, Mark = 75, Name = "Biology" }
                },
                Standing = STANDING.MagnaCumLaude
            },
            new Student()
            {
                Id = 1,
                Courses = new Course[] {
                    new Course() { Id = 1, Mark = 40, Name = "Physics" },
                    new Course() { Id = 2, Mark = 64, Name = "Chemistry" },
                    new Course() { Id = 3, Mark = 60, Name = "Maths" },
                    new Course() { Id = 4, Mark = 68, Name = "Biology" }
                },
                Standing = STANDING.Average
            }
        };

        public List<Diploma> Diplomas => new List<Diploma>() {
            new Diploma()
            {
                Id = 1,
                Credits = 12,
                Requirements = new int[] { 1, 2}
            }
        };

        public List<Requirement> Requirements => new List<Requirement>() {
            new Requirement()
            {
                Id = 1,
                Credits = 6,
                MinimumMark = 50,
                Courses = new int[] { 1, 2 },
                Name = "Requirement1"
            },
            new Requirement()
            {
                Id = 2,
                Credits = 6,
                MinimumMark = 70,
                Courses = new int[] { 3, 4 },
                Name = "Requirement2"
            }

        };
    }
}
