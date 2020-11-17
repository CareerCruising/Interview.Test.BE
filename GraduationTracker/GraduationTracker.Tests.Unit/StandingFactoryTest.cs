using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationTracker.Tests.Unit
{
    /// <summary>
    /// Test class to test the StandingFactory whether the factory class provides the appropriate instance based on average
    /// </summary>
    [TestClass]
    public class StandingFactoryTest
    {

        [TestMethod]
        public void AverageMarksLessThan50Test()
        {
            IGraduationStandingRetriever standingInstance = StandingFactory.GetStandingInstance(45);
            Assert.IsTrue(standingInstance is StandingRemedial);
        }

        [TestMethod]
        public void AverageMarksLessThan75Test()
        {
            IGraduationStandingRetriever standingInstance = StandingFactory.GetStandingInstance(75);
            Assert.IsTrue(standingInstance is StandingAverage);
        }

        [TestMethod]
        public void AverageMarksLessThan85Test()
        {
            IGraduationStandingRetriever standingInstance = StandingFactory.GetStandingInstance(85);
            Assert.IsTrue(standingInstance is StandingMagnaCumLaude);
        }

        [TestMethod]
        public void AverageMarksLessThan98Test()
        {
            IGraduationStandingRetriever standingInstance = StandingFactory.GetStandingInstance(98);
            Assert.IsTrue(standingInstance is StandingSumaCumLaude);
        }
    }
}
