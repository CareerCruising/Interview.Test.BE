using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationTracker.Tests.Unit
{
    /// <summary>
    /// Test the graduation status & standing for StandingSumaCumLaude
    /// </summary>
    [TestClass]
    public class StandingSumaCumLaudeTest
    {
        [TestMethod]
        public void SumaCumLaudeGraduationStatusStandingTest()
        {
            var actualResult = new StandingSumaCumLaude().getGraduationStatusStanding();
            var expectedResult = new Tuple<bool, STANDING>(true, STANDING.SumaCumLaude);
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void SumaCumLaudeGraduationStatusStandingByAverage98Test()
        {
            IGraduationStandingRetriever standingInstance = StandingFactory.GetStandingInstance(98);
            var actualResult = standingInstance.getGraduationStatusStanding();
            var expectedResult = new Tuple<bool, STANDING>(true, STANDING.SumaCumLaude);
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void SumaCumLaudeGraduationStatusStandingByAverage45Test()
        {
            IGraduationStandingRetriever standingInstance = StandingFactory.GetStandingInstance(45);
            var actualResult = standingInstance.getGraduationStatusStanding();
            var expectedResult = new Tuple<bool, STANDING>(true, STANDING.SumaCumLaude);
            Assert.AreNotEqual(actualResult, expectedResult);
        }
    }
}
