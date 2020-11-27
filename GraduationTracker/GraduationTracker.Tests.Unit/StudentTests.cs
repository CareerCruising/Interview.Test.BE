using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraduationTracker.Tests
{
    [TestClass()]
    public class StudentTests
    {
        public StudentTests()
        {
            RepositoryFactoryBase.RepositoryFactoryName = "RepositoryFactory";
            RepositoryFactoryBase.RepositoryFactoryNamespace = "GraduationTracker";
            RepositoryFactoryBase.Refresh();
        }

        [TestMethod()]
        public void StudentTest()
        {
            DiplomaRepository diplomaRepository = new DiplomaRepository();
            Diploma diploma = diplomaRepository.GetDiploma(1);
            Student student = new Student(diploma, 1);

            Assert.IsNotNull(diploma);
            Assert.IsNotNull(student);
            Assert.AreEqual(student.CourseCount, 4);
        }

        [TestMethod()]
        public void IsGraduatedTestTrue()
        {
            DiplomaRepository diplomaRepository = new DiplomaRepository();
            Diploma diploma = diplomaRepository.GetDiploma(1);
            Student student = new Student(diploma, 1);

            
            Assert.IsTrue(student.IsGraduated());
        }

        [TestMethod()]
        public void IsGraduatedTestFalse()
        {
            DiplomaRepository diplomaRepository = new DiplomaRepository();
            Diploma diploma = diplomaRepository.GetDiploma(1);
            Student student = new Student(diploma, 4);

            Assert.IsFalse(student.IsGraduated());
        }

        [TestMethod()]
        public void GetAverageTest()
        {
            DiplomaRepository diplomaRepository = new DiplomaRepository();
            Diploma diploma = diplomaRepository.GetDiploma(1);
            Student student = new Student(diploma, 1);

            Assert.AreEqual(student.GetAverage(), 95m);
        }

        [TestMethod()]
        public void GetRequirementAverageTest()
        {
            DiplomaRepository diplomaRepository = new DiplomaRepository();
            Diploma diploma = diplomaRepository.GetDiploma(1);
            Student student = new Student(diploma, 1);

            Assert.AreEqual(student.GetRequirementAverage(), 95m);
        }

        [TestMethod()]
        public void GetCreditsTestPositive()
        {
            DiplomaRepository diplomaRepository = new DiplomaRepository();
            Diploma diploma = diplomaRepository.GetDiploma(1);
            Student student = new Student(diploma, 1);

            Assert.AreEqual(student.GetCredits(), 4);
        }

        [TestMethod()]
        public void GetCreditsTestNothing()
        {
            DiplomaRepository diplomaRepository = new DiplomaRepository();
            Diploma diploma = diplomaRepository.GetDiploma(1);
            Student student = new Student(diploma, 4);

            Assert.AreEqual(student.GetCredits(), 0);
        }

        [TestMethod()]
        public void GetStandingsTest95Plus()
        {
            DiplomaRepository diplomaRepository = new DiplomaRepository();
            Diploma diploma = diplomaRepository.GetDiploma(1);
            Student student = new Student(diploma, 1);

            student.GetRequirementAverage();

            Assert.AreEqual(student.GetStandings(), Student.Standings.SumaCumLaude);
        }

        [TestMethod()]
        public void GetStandingsTest45()
        {
            DiplomaRepository diplomaRepository = new DiplomaRepository();
            Diploma diploma = diplomaRepository.GetDiploma(1);
            Student student = new Student(diploma, 4);

            student.GetRequirementAverage();

            Assert.AreEqual(student.GetStandings(), Student.Standings.Remedial);
        }
    }
}