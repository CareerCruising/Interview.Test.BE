using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        #region TestData
       
         // Reusing the test data for both of test cases          
        
        GraduationTracker tracker = new GraduationTracker();
        //Get the testdata from Repository class
        Diploma diploma = Repository.GetDiploma(1);

        Student[] studentTestData = new[]
        {
                Repository.GetStudent(1),
                Repository.GetStudent(2),
                Repository.GetStudent(3),
                Repository.GetStudent(4)
            };
        #endregion
        public List<Tuple<bool, STANDING>> GetStudentsData()
        {
            var graduated = new List<Tuple<bool, STANDING>>();

            foreach (var student in studentTestData)
            {
                graduated.Add(tracker.HasGraduated(diploma, student));
            }
            return graduated;
        }
                 
        [TestMethod]
        /// <summary>
        /// Test case to know if any student has no credits or failed.
        /// Now the test has only single  responsible to check for GraduationFailed Student
        /// </summary>  
        public void GraduationFailedTests()
        {

            var graduated = GetStudentsData();
            Assert.IsFalse(graduated.Any(x => x.Item2 == STANDING.None));
            Assert.IsTrue(graduated.Any(x => x.Item1 == false));
            Assert.IsTrue(graduated.Any(x => x.Item2 == STANDING.Remedial));
        }

      
        [TestMethod]
        /// <summary>
        /// Method:HasCreditsTest
        /// Test case to test  if any students has credits.
        /// </summary>
        public void HasCreditsTests()
        {
            var graduated = GetStudentsData();
            Assert.IsTrue(graduated.Any());
            Assert.IsTrue(graduated.Count == 4);
            Assert.IsTrue(graduated[1].Item2 == STANDING.MagnaCumLaude);
        
        }

    }
}
