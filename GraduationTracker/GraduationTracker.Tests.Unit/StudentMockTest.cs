using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraduationTracker.Tests.Unit
{
    [TestClass()]
    public class StudentMockTest
    {
        public StudentMockTest()
        {
            RepositoryFactoryBase.RepositoryFactoryName = "Mocks.RepositoryFactoryMock";
            RepositoryFactoryBase.RepositoryFactoryNamespace = "GraduationTracker.Tests.Unit";
            RepositoryFactoryBase.Refresh();
        }

        [TestMethod()]
        public void IsGraduatedTestFalse()
        {
            DiplomaRepository diplomaRepository = RepositoryFactoryBase.Instance.Value.CreateDiplomaRepository();
            Diploma diploma = diplomaRepository.GetDiploma(1);
            Student student = new Student(diploma, 5);


            Assert.IsFalse(student.IsGraduated());
        }

        [TestMethod()]
        public void IsGraduatedTestTrue()
        {
            DiplomaRepository diplomaRepository = RepositoryFactoryBase.Instance.Value.CreateDiplomaRepository();
            Diploma diploma = diplomaRepository.GetDiploma(1);
            Student student = new Student(diploma, 6);

            Assert.IsFalse(student.IsGraduated());
        }

        [TestMethod()]
        public void GetAverageVsRequirementAverageTest()
        {
            DiplomaRepository diplomaRepository = RepositoryFactoryBase.Instance.Value.CreateDiplomaRepository();
            Diploma diploma = diplomaRepository.GetDiploma(1);
            Student student = new Student(diploma, 5);

            Assert.AreNotEqual(student.GetAverage(), student.GetRequirementAverage());
            Assert.AreEqual(student.GetAverage(), 57.5m);
            Assert.AreEqual(student.GetRequirementAverage(), 160m / 3m);
        }

        [TestMethod()]
        public void GetCredits3CreditsTest()
        {
            DiplomaRepository diplomaRepository = new DiplomaRepository();
            Diploma diploma = diplomaRepository.GetDiploma(1);
            Student student = new Student(diploma, 5);

            Assert.AreEqual(student.GetCredits(), 3);
        }

        [TestMethod()]
        public void GetCredits4CreditsTest()
        {
            DiplomaRepository diplomaRepository = new DiplomaRepository();
            Diploma diploma = diplomaRepository.GetDiploma(1);
            Student student = new Student(diploma, 6);

            Assert.AreEqual(student.GetCredits(), 4);
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
            Student student = new Student(diploma, 5);

            student.GetRequirementAverage();

            Assert.AreEqual(student.GetStandings(), Student.Standings.Average);
        }
    }
}
