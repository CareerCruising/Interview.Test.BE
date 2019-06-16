using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        /// <summary>
        /// Should pass for a Student that have graduated.
        /// </summary>
        [TestMethod]
        public void TestHasGraduated()
        {
            // Create a new tracker
            var tracker = new GraduationTracker();

            // Hold those who graduated
            var graduated = new List<Tuple<bool, STANDING>>();

            // Retrieve diploma and students from the repository, allowing 
            // many tests to have access without duplicate or recreate 
            // the data for each test
            var diploma = Repository.GetDiploma(1);

            var students = new List<Student>();

            students.Add(Repository.GetStudent(1));
            students.Add(Repository.GetStudent(2));            
            students.Add(Repository.GetStudent(3));
            //students.Add(Repository.GetStudent(4)); // This should fail the test
            students.Add(Repository.GetStudent(5));
            //students.Add(Repository.GetStudent(6)); // This should fail the test

            // Iterate over students
            foreach (var s in students)
            {
                // Call the tracker for the student
                var t = tracker.HasGraduated(diploma, s);

                // Fail the test if diploma == false in the returned tuple
                if (t.Item1 == false) Assert.Fail();
            }
        }

        /// <summary>
        /// Should pass for a Student that have NOT graduated.
        /// </summary>
        [TestMethod]
        public void TestHasNotGraduated()
        {
            // Create a new tracker
            var tracker = new GraduationTracker();

            // Hold those who graduated
            var graduated = new List<Tuple<bool, STANDING>>();

            // Retrieve diploma and students from the repository, allowing 
            // many tests to have access without duplicate or recreate 
            // the data for each test
            var diploma = Repository.GetDiploma(1);

            var students = new List<Student>();

            //students.Add(Repository.GetStudent(1)); // This should fail the test
            //students.Add(Repository.GetStudent(2)); // This should fail the test
            //students.Add(Repository.GetStudent(3)); // This should fail the test
            students.Add(Repository.GetStudent(4));
            //students.Add(Repository.GetStudent(5)); // This should fail the test
            students.Add(Repository.GetStudent(6));

            // Iterate over students
            foreach (var s in students)
            {
                // Call the tracker for the student
                var t = tracker.HasGraduated(diploma, s);

                // Fail the test if diploma == true in the returned tuple
                if (t.Item1 == true) Assert.Fail();
            }
        }

        /// <summary>
        /// Should pass for a Student that have credits from its courses.
        /// </summary>
        [TestMethod]
        public void TestHasCredits()
        {
            // Create a new tracker
            var tracker = new GraduationTracker();

            // Retrieve diploma and students from the repository, allowing 
            // many tests to have access without duplicate or recreate 
            // the data for each test
            var diploma = Repository.GetDiploma(1);

            var students = new List<Student>();

            students.Add(Repository.GetStudent(1));
            students.Add(Repository.GetStudent(2));
            //students.Add(Repository.GetStudent(3)); // This should fail the test
            //students.Add(Repository.GetStudent(4)); // This should fail the test
            students.Add(Repository.GetStudent(5));
            students.Add(Repository.GetStudent(6));

            // Iterate over students
            foreach (var s in students)
            {
                // Call the tracker for the student
                var t = tracker.HasGraduated(diploma, s);

                // Hold the student's credits for each course
                var sCredits = 0;

                // Iterate over the courses for each student
                foreach (var c in s.Courses)
                {
                    // Return the credits for the course
                    sCredits += c.Credits;
                }

                // Fail the test if the student DON'T HAVE credits
                if (sCredits <= 0) Assert.Fail();
            }
        }

        /// <summary>
        /// Should pass for a Student that do NOT have credits from its courses.
        /// </summary>
        [TestMethod]
        public void TestHasNoCredits()
        {
            // Create a new tracker
            var tracker = new GraduationTracker();

            // Retrieve diploma and students from the repository, allowing 
            // many tests to have access without duplicate or recreate 
            // the data for each test
            var diploma = Repository.GetDiploma(1);

            var students = new List<Student>();

            //students.Add(Repository.GetStudent(1)); // This should fail the test
            //students.Add(Repository.GetStudent(2)); // This should fail the test
            students.Add(Repository.GetStudent(3));
            students.Add(Repository.GetStudent(4));
            //students.Add(Repository.GetStudent(5)); // This should fail the test
            //students.Add(Repository.GetStudent(6)); // This should fail the test

            // Iterate over students
            foreach (var s in students)
            {
                // Call the tracker for the student
                var t = tracker.HasGraduated(diploma, s);

                // Hold the student's credits for each course
                var sCredits = 0;

                // Iterate over the courses for each student
                foreach (var c in s.Courses)
                {
                    // Return the credits for the course
                    sCredits += c.Credits;
                }

                // Fail the test if the student HAVE credits
                if (sCredits > 0) Assert.Fail();
            }
        }
    }
}