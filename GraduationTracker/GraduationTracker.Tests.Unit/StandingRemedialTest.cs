using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationTracker.Tests.Unit
{
    /// <summary>
    /// Test the graduation status & standing for StandingRemedial
    /// </summary>
    [TestClass]
    public class StandingRemedialTest
    {
        [TestMethod]
        public void RemedialGraduationStatusStandingTest()
        {
            var actualResult = new StandingRemedial().getGraduationStatusStanding();
            var expectedResult = new Tuple<bool, STANDING>(false, STANDING.Remedial);
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void RemedialGraduationStatusStandingByAverage45Test()
        {
            IGraduationStandingRetriever standingInstance = StandingFactory.GetStandingInstance(45);
            var actualResult = standingInstance.getGraduationStatusStanding();
            var expectedResult = new Tuple<bool, STANDING>(false, STANDING.Remedial);
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void RemedialGraduationStatusStandingByAverage98Test()
        {
            IGraduationStandingRetriever standingInstance = StandingFactory.GetStandingInstance(98);
            var actualResult = standingInstance.getGraduationStatusStanding();
            var expectedResult = new Tuple<bool, STANDING>(false, STANDING.Remedial);
            Assert.AreNotEqual(actualResult, expectedResult);
        }
    }
}
