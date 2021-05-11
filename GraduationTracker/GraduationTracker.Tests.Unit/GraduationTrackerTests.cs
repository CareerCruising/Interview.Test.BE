using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using GraduationTracker.Repositories;
using GraduationTracker.GraduationTrackers;
using GraduationTracker.Students;
using GraduationTracker.Diplomas;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {

        [TestMethod]
        public void TestStudentsFailedInMath()
        {
            IEnumerable<IStudent> students = Repository.GetStudents();
            IDiploma diploma = Repository.GetDiploma(1);

            StudentsGraduationTracker tracker = new StudentsGraduationTracker(students, diploma);

            IEnumerable<IStudent> studentsFailedInMath = tracker.GetStudentsFailedInMath();


            Assert.IsTrue(studentsFailedInMath.Count() == 1);

        }

        [TestMethod]
        public void TestStudentsApprovedInScience()
        {
            IEnumerable<IStudent> students = Repository.GetStudents();
            IDiploma diploma = Repository.GetDiploma(1);

            StudentsGraduationTracker tracker = new StudentsGraduationTracker(students, diploma);

            IEnumerable<IStudent> studentsFailedInMath = tracker.GetStudentsApprovedInScience();


            Assert.IsTrue(studentsFailedInMath.Count() == 2);

        }


        [TestMethod]
        public void TestStudentIsGraduated()
        {

            IStudent student = Repository.GetStudent(2);
            IDiploma diploma = Repository.GetDiploma(1);
            StudentGraduationTracker tracker = new StudentGraduationTracker(student, diploma);

            ResultGraduationTracker result = tracker.StudentHasGraduated();

            Assert.IsTrue(result.IsGraduated);
            Assert.IsTrue(result.Standing == Standing.MagnaCumLaude);
            // not too sure about this bussiness rule
            Assert.IsTrue(result.Credits > 1);


        }


        public void TestStudentIsNotGraduated()
        {

            IStudent student = Repository.GetStudent(4);
            IDiploma diploma = Repository.GetDiploma(1);
            StudentGraduationTracker tracker = new StudentGraduationTracker(student, diploma);

            ResultGraduationTracker result = tracker.StudentHasGraduated();

            

            Assert.IsFalse(result.IsGraduated);
            Assert.IsTrue(result.Standing == Standing.Remedial);

        }

    }
}
