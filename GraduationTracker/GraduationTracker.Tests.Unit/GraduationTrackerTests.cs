using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        [TestMethod]
        public void TestHasCredits()
        {
            var tracker = new GraduationTracker();

            var diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            var students = new[]
            {
               new Student { Id = 1 },
               new Student { Id = 2 },
               new Student { Id = 3 },
               new Student { Id = 4 },
               new Student { Id = 5 }
            };

            var graduated = new List<Tuple<bool, STANDING>>();

            foreach (var student in students)
            {
                graduated.Add(tracker.HasGraduated(diploma, student));
            }

            Assert.IsTrue(graduated.Count(s => !s.Item1) == 3);
            Assert.IsTrue(tracker.HasGraduated(diploma, students[0]).Item1);
            Assert.IsTrue(tracker.HasGraduated(diploma, students[1]).Item1);
            Assert.IsFalse(tracker.HasGraduated(diploma, students[2]).Item1);   //Not enough credits
            Assert.IsFalse(tracker.HasGraduated(diploma, students[3]).Item1);   //Average is not meeting the requirement
            Assert.IsFalse(tracker.HasGraduated(diploma, students[4]).Item1);   //Not enough credits
        }
    }
}
