using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationTracker.Tests.Unit
{
    /// <summary>
    /// Test the graduation status & standing for StandingAverage
    /// </summary>
    [TestClass]
    public class StandingAverageTest
    {
        [TestMethod]
        public void AverageGraduationStatusStandingTest()
        {
            var actualResult = new StandingAverage().getGraduationStatusStanding();
            var expectedResult = new Tuple<bool, STANDING>(true, STANDING.Average);
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void AverageGraduationStatusStandingByAverage60Test()
        {
            IGraduationStandingRetriever standingInstance = StandingFactory.GetStandingInstance(60);
            var actualResult = standingInstance.getGraduationStatusStanding();
            var expectedResult = new Tuple<bool, STANDING>(true, STANDING.Average);
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void AverageGraduationStatusStandingByAverage45Test()
        {
            IGraduationStandingRetriever standingInstance = StandingFactory.GetStandingInstance(45);
            var actualResult = standingInstance.getGraduationStatusStanding();
            var expectedResult = new Tuple<bool, STANDING>(true, STANDING.Average);
            Assert.AreNotEqual(actualResult, expectedResult);
        }
    }
}
