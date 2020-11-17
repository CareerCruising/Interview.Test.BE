using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationTracker.Tests.Unit
{
    /// <summary>
    /// Test the graduation status & standing for StandingMagnaCumLaude
    /// </summary>
    [TestClass]
    public class StandingMagnaCumLaudeTest
    {
        [TestMethod]
        public void MagnaCumLaudeGraduationStatusStandingTest()
        {
            var actualResult = new StandingMagnaCumLaude().getGraduationStatusStanding();
            var expectedResult = new Tuple<bool, STANDING>(true, STANDING.MagnaCumLaude);
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void MagnaCumLaudeGraduationStatusStandingByAverage85Test()
        {
            IGraduationStandingRetriever standingInstance = StandingFactory.GetStandingInstance(85);
            var actualResult = standingInstance.getGraduationStatusStanding();
            var expectedResult = new Tuple<bool, STANDING>(true, STANDING.MagnaCumLaude);
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void MagnaCumLaudeGraduationStatusStandingByAverage45Test()
        {
            IGraduationStandingRetriever standingInstance = StandingFactory.GetStandingInstance(45);
            var actualResult = standingInstance.getGraduationStatusStanding();
            var expectedResult = new Tuple<bool, STANDING>(true, STANDING.MagnaCumLaude);
            Assert.AreNotEqual(actualResult, expectedResult);
        }
    }
}
