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
        public void HasGraduated_ThreeStudentsPassesOneFail_ThreeTrueOneFalse()
        {
            // Arrange
            GraduationTracker tracker = new GraduationTracker();

            Diploma diploma = Repository.GetDiploma(1);

            List<Student> students = GetStudents();

            List<Tuple<bool, STANDING>> graduated = new List<Tuple<bool, STANDING>>();

            // Act
            foreach (Student student in students)
            {
                graduated.Add(tracker.HasGraduated(diploma, student));
            }

            // Assert
            int totalPass = graduated.Count(a => a.Item2 != STANDING.Remedial);
            int totalFail = graduated.Count(a => a.Item2 == STANDING.Remedial);
            Assert.AreEqual(3, totalPass);
            Assert.AreEqual(1, totalFail);
        }

        [TestMethod]
        public void HasGraduated_AllStudentsFail_AllFalse()
        {
            // Arrange
            GraduationTracker tracker = new GraduationTracker();

            Diploma diploma = Repository.GetDiploma(1);

            List<Student> students = MockGetStudents(new[] { 49, 30, 20, 0 });

            List<Tuple<bool, STANDING>> graduated = new List<Tuple<bool, STANDING>>();

            // Act
            foreach (Student student in students)
            {
                graduated.Add(tracker.HasGraduated(diploma, student));
            }

            // Assert
            int totalFail = graduated.Count(a => a.Item2 == STANDING.Remedial);
            Assert.AreEqual(students.Count, totalFail);
        }

        [TestMethod]
        public void HasGraduated_AllStudentsPass_AllTrue()
        {
            // Arrange
            GraduationTracker tracker = new GraduationTracker();

            Diploma diploma = Repository.GetDiploma(1);

            List<Student> students = MockGetStudents(new[] { 100, 90, 80, 50 });

            List<Tuple<bool, STANDING>> graduated = new List<Tuple<bool, STANDING>>();

            // Act
            foreach (Student student in students)
            {
                graduated.Add(tracker.HasGraduated(diploma, student));
            }

            // Assert
            int totalPass = graduated.Count(a => a.Item2 != STANDING.Remedial);
            Assert.AreEqual(students.Count, totalPass);
        }

        [TestMethod]
        public void Student_GraduatedWithMagnaCumLaude_HasSameStanding()
        {
            // Arrange
            GraduationTracker tracker = new GraduationTracker();

            Diploma diploma = Repository.GetDiploma(1);

            Student student = MockGetStudents(new[] { 100 }).First();

            List<Tuple<bool, STANDING>> graduated = new List<Tuple<bool, STANDING>>();

            // Act
            var result = tracker.HasGraduated(diploma, student);
            student.Standing = result.Item2;

            // Assert
            Assert.AreEqual(STANDING.MagnaCumLaude, student.Standing);
        }

        [TestMethod]
        public void Diploma_SumCreditsRequirement_IsEqualToDiploma()
        {
            // Arrange
            Diploma diploma = Repository.GetDiploma(1);

            // Act
            var sumRequirementsCredits = 0;
            for (int i = 0; i < diploma.Requirements.Length; i++)
            {
                sumRequirementsCredits += Repository.GetRequirement(diploma.Requirements[i]).Credits;
            }

            // Assert
            Assert.AreEqual(diploma.Credits, sumRequirementsCredits);
        }

        #region Mock Methods

        private List<Student> GetStudents()
        {
            List<Student> list = new List<Student>
            {
                Repository.GetStudent(1),
                Repository.GetStudent(2),
                Repository.GetStudent(3),
                Repository.GetStudent(4)
            };

            return list;
        }

        private List<Student> MockGetStudents(int[] marks)
        {
            List<Student> listStudents = new List<Student>();

            for (int i = 0; i < marks.Length; i++)
            {
                Student student = new Student
                {
                    Id = i + 1,
                    Courses = MockGetCourses(marks[i])
                };
                listStudents.Add(student);
            }

            return listStudents;
        }

        private Course[] MockGetCourses(int mark)
        {
            return new[]
            {
                new Course {Id = 1, Name = "Math", Mark = mark},
                new Course {Id = 2, Name = "Science", Mark = mark},
                new Course {Id = 3, Name = "Literature", Mark = mark},
                new Course {Id = 4, Name = "Physichal Education", Mark = mark}
            };
        }
        #endregion
    }
}
