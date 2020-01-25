using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraduationTracker.Tests.Unit.FakeServices;
using GraduationTracker.Models;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
      
        [TestMethod]
        [Description("Test for student has credit")]
        public void TestHasCredits()
        {
            // Arrange
            var trackerCreditZero = new GraduationTracker(new FakeDiplomaService(6), new FakeStudentService(Standing.None, 0));
            var trackerCreditOne = new GraduationTracker(new FakeDiplomaService(6), new FakeStudentService(Standing.None, 1));
            var trackerCreditNegative = new GraduationTracker(new FakeDiplomaService(6), new FakeStudentService(Standing.None, -1));

            // Act

            var actualCreditZero = trackerCreditZero.HasCredits();
            var actualCreditOne = trackerCreditOne.HasCredits();
            var actualCreditNegative = trackerCreditNegative.HasCredits();

            // Assert

            Assert.IsFalse(actualCreditZero);
            Assert.IsTrue(actualCreditOne);
            Assert.IsFalse(actualCreditNegative);

        }

        
        [TestMethod]
        [Description((@"Test for student should graduate if credit earned is equal or greater than credit offered by diploma
                       Keeping standing condition constant and fulfilled"))]
        public void TestHasGraduated_BasedOnCreditEarnedCondition()
        {

            // Arrange
            var stubTracker1 = new GraduationTracker(new FakeDiplomaService(6), new FakeStudentService(Standing.Average, 6));
            var stubTracker2 = new GraduationTracker(new FakeDiplomaService(6), new FakeStudentService(Standing.MagnaCumLaude, 7));
            var stubTracker3 = new GraduationTracker(new FakeDiplomaService(6), new FakeStudentService(Standing.SumaCumLaude, 2));

            // Action

            var actual1 = stubTracker1.HasGraduated();
            var actual2 = stubTracker2.HasGraduated();
            var actual3 = stubTracker3.HasGraduated();

            // Assert

            Assert.IsTrue(actual1);
            Assert.IsTrue(actual2);
            Assert.IsFalse(actual3);
        }

        [TestMethod]
        [Description(@"Test for student should graduate if standing is not {Remedial,None}
                        Keeping credit earned condition constant and fulfilled")]
        public void TestHasGraduated_BasedOnStanding()
        {
           
            // Arrange
            var stubTrackerStandingNone = new GraduationTracker(new FakeDiplomaService(6), new FakeStudentService(Standing.None, 6));
            var stubTrackerStandingRemedial = new GraduationTracker(new FakeDiplomaService(6), new FakeStudentService(Standing.Remedial, 6));
            var stubTrackerStandingAverage = new GraduationTracker(new FakeDiplomaService(6), new FakeStudentService(Standing.Average, 6));
            var stubTrackerStandingMag = new GraduationTracker(new FakeDiplomaService(6), new FakeStudentService(Standing.MagnaCumLaude, 6));
            var stubTrackerStandingSuma = new GraduationTracker(new FakeDiplomaService(6), new FakeStudentService(Standing.SumaCumLaude, 6));

            // Action

            var actualStandingNone = stubTrackerStandingNone.HasGraduated();
            var actualStandingRemedial = stubTrackerStandingRemedial.HasGraduated();
            var actualStandingAverage = stubTrackerStandingAverage.HasGraduated();
            var actualStandingMag = stubTrackerStandingMag.HasGraduated();
            var actualStandingSuma = stubTrackerStandingSuma.HasGraduated();

            // Assert

            Assert.IsFalse(actualStandingNone);
            Assert.IsFalse(actualStandingRemedial);
            Assert.IsTrue(actualStandingAverage);
            Assert.IsTrue(actualStandingMag);
            Assert.IsTrue(actualStandingSuma);
        }


        [TestMethod]
        [Description("Test for student should graduate for both condition")]
        public void TestGraduated_BasedOnBothCondition()
        {
            // Arrange
            var stubTrackerBothUnSatisfied = new GraduationTracker(new FakeDiplomaService(6), new FakeStudentService(Standing.None, 5));
            var stubTrackerOneSatisfied = new GraduationTracker(new FakeDiplomaService(6), new FakeStudentService(Standing.Remedial, 6));
            var stubTrackerBothSatisfied = new GraduationTracker(new FakeDiplomaService(6), new FakeStudentService(Standing.MagnaCumLaude, 6));

            // Action
            var actualBothUnSatisfied = stubTrackerBothUnSatisfied.HasGraduated();
            var actualOneSatisfied = stubTrackerOneSatisfied.HasGraduated();
            var actualBothSatisfied = stubTrackerBothSatisfied.HasGraduated();

            // Assert
            Assert.IsFalse(actualBothUnSatisfied);
            Assert.IsFalse(actualOneSatisfied);
            Assert.IsTrue(actualBothSatisfied);
        }
    }
}
