using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        [TestMethod]
        public void TestHasGraduated()
        {
            GraduationTracker tracker = new GraduationTracker();

            // set diploma id
            int diplomaId = 1;

            // set student ids
            int[] studentIds = new int[] { 1, 2, 3, 4 };

            List<Tuple<bool, STANDING>> graduated = new List<Tuple<bool, STANDING>>();

            foreach (int studentId in studentIds)
            {
                Student student = tracker.GetStudentById(studentId);
                Diploma diploma = tracker.GetDiplomaById(diplomaId);

                // add tracking info to graduated list
                graduated.Add(tracker.HasGraduated(diploma, student));

                Course[] courses = student.Courses;

                // validations with dynamic variables
                bool isFailed = false;
                int average = 0;

                foreach (Course course in courses)
                {
                    if (course.Mark < 50)
                    {
                        isFailed = true;
                        break;
                    }

                    average += course.Mark;
                }

                average = average / courses.Length;

                if (average < 50)
                {
                    isFailed = true;
                }

                // check false if a student failed a course, check true if a student passed all courses
                if (isFailed)
                {
                    Assert.IsFalse(
                        graduated[graduated.Count - 1].Item1,
                        "Validation Failed: Graduated while it doesn't fulfill all requirements for the student " +
                        student.Id
                        );
                }
                else
                {
                    Assert.IsTrue(
                        graduated[graduated.Count - 1].Item1,
                        "Validation Failed: Not graduated while it fulfill all requirements for the student " +
                        student.Id
                        );
                }
            }
        }
    }
}
