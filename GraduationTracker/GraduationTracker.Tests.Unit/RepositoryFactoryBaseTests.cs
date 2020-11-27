using GraduationTracker.Tests.Unit.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace GraduationTracker.Tests
{
    [TestClass()]
    public class RepositoryFactoryBaseTests
    {
        [TestMethod()]
        public void FactorySingletonTest()
        {
            RepositoryFactoryBase.RepositoryFactoryName = "RepositoryFactory";
            RepositoryFactoryBase.RepositoryFactoryNamespace = "GraduationTracker";
            RepositoryFactoryBase.Refresh();
            RepositoryFactoryBase repositoryFactory = RepositoryFactoryBase.Instance.Value;

            Assert.IsNotNull(repositoryFactory);
            Assert.AreEqual(repositoryFactory.GetType(), typeof(RepositoryFactory));
            Assert.AreEqual(RepositoryFactoryBase.RepositoryFactoryName, "RepositoryFactory");
            Assert.AreEqual(RepositoryFactoryBase.RepositoryFactoryNamespace, "GraduationTracker");
        }

        [TestMethod()]
        public void CreateCourseRepositoryTest()
        {
            RepositoryFactoryBase.RepositoryFactoryName = "RepositoryFactory";
            RepositoryFactoryBase.RepositoryFactoryNamespace = "GraduationTracker";
            RepositoryFactoryBase.Refresh();
            RepositoryFactoryBase repositoryFactory = RepositoryFactoryBase.Instance.Value;
            CourseRepository courseRepository = repositoryFactory.CreateCourseRepository();

            Assert.IsNotNull(courseRepository);
            Assert.AreEqual(courseRepository.GetType(), typeof(CourseRepository));
        }

        [TestMethod()]
        public void CreateDiplomaRepositoryTest()
        {
            RepositoryFactoryBase.RepositoryFactoryName = "RepositoryFactory";
            RepositoryFactoryBase.RepositoryFactoryNamespace = "GraduationTracker";
            RepositoryFactoryBase.Refresh();
            RepositoryFactoryBase repositoryFactory = RepositoryFactoryBase.Instance.Value;
            DiplomaRepository diplomaRepository = repositoryFactory.CreateDiplomaRepository();

            Assert.IsNotNull(diplomaRepository);
            Assert.AreEqual(diplomaRepository.GetType(), typeof(DiplomaRepository));
        }

        [TestMethod()]
        public void CreateDiplomaRequirementRepositoryTest()
        {
            RepositoryFactoryBase.RepositoryFactoryName = "RepositoryFactory";
            RepositoryFactoryBase.RepositoryFactoryNamespace = "GraduationTracker";
            RepositoryFactoryBase.Refresh();
            RepositoryFactoryBase repositoryFactory = RepositoryFactoryBase.Instance.Value;
            DiplomaRequirementRepository diplomaRequirementRepository = repositoryFactory.CreateDiplomaRequirementRepository();

            Assert.IsNotNull(diplomaRequirementRepository);
            Assert.AreEqual(diplomaRequirementRepository.GetType(), typeof(DiplomaRequirementRepository));
        }

        [TestMethod()]
        public void CreateRequirementCourseRepositoryTest()
        {
            RepositoryFactoryBase.RepositoryFactoryName = "RepositoryFactory";
            RepositoryFactoryBase.RepositoryFactoryNamespace = "GraduationTracker";
            RepositoryFactoryBase.Refresh();
            RepositoryFactoryBase repositoryFactory = RepositoryFactoryBase.Instance.Value;
            RequirementCourseRepository requirementCourseRepository = repositoryFactory.CreateRequirementCourseRepository();

            Assert.IsNotNull(requirementCourseRepository);
            Assert.AreEqual(requirementCourseRepository.GetType(), typeof(RequirementCourseRepository));
        }

        [TestMethod()]
        public void CreateRequirementRepositoryTest()
        {
            RepositoryFactoryBase.RepositoryFactoryName = "RepositoryFactory";
            RepositoryFactoryBase.RepositoryFactoryNamespace = "GraduationTracker";
            RepositoryFactoryBase.Refresh();
            RepositoryFactoryBase repositoryFactory = RepositoryFactoryBase.Instance.Value;
            RequirementRepository requirementRepository = repositoryFactory.CreateRequirementRepository();

            Assert.IsNotNull(requirementRepository);
            Assert.AreEqual(requirementRepository.GetType(), typeof(RequirementRepository));
        }

        [TestMethod()]
        public void CreateStudentCourseRepositoryTest()
        {
            RepositoryFactoryBase.RepositoryFactoryName = "RepositoryFactory";
            RepositoryFactoryBase.RepositoryFactoryNamespace = "GraduationTracker";
            RepositoryFactoryBase.Refresh();
            RepositoryFactoryBase repositoryFactory = RepositoryFactoryBase.Instance.Value;
            StudentCourseRepository studentCourseRepository = repositoryFactory.CreateStudentCourseRepository();

            Assert.IsNotNull(studentCourseRepository);
            Assert.AreEqual(studentCourseRepository.GetType(), typeof(StudentCourseRepository));
        }

        [TestMethod()]
        public void CreateStudentRepositoryTest()
        {
            RepositoryFactoryBase.RepositoryFactoryName = "RepositoryFactory";
            RepositoryFactoryBase.RepositoryFactoryNamespace = "GraduationTracker";
            RepositoryFactoryBase.Refresh();
            RepositoryFactoryBase repositoryFactory = RepositoryFactoryBase.Instance.Value;
            DiplomaRepository diplomaRepository = repositoryFactory.CreateDiplomaRepository();
            Diploma diploma = diplomaRepository.GetDiploma().FirstOrDefault();
            StudentRepository studentRepository = repositoryFactory.CreateStudentRepository(diploma);

            Assert.IsNotNull(studentRepository);
            Assert.AreEqual(studentRepository.GetType(), typeof(StudentRepository));
        }

        [TestMethod()]
        public void RefreshTest()
        {
            RepositoryFactoryBase.RepositoryFactoryName = "Mocks.RepositoryFactoryMock";
            RepositoryFactoryBase.RepositoryFactoryNamespace = "GraduationTracker.Tests.Unit";
            RepositoryFactoryBase.Refresh();

            RepositoryFactoryBase repositoryFactory = RepositoryFactoryBase.Instance.Value;
            DiplomaRepository diplomaRepository = repositoryFactory.CreateDiplomaRepository();
            Diploma diploma = diplomaRepository.GetDiploma().FirstOrDefault();
            CourseRepository courseRepository = repositoryFactory.CreateCourseRepository();
            StudentCourseRepository studentCourseRepository = repositoryFactory.CreateStudentCourseRepository();
            StudentRepository studentRepository = repositoryFactory.CreateStudentRepository(diploma);

            Assert.IsNotNull(repositoryFactory);
            Assert.IsNotNull(courseRepository);
            Assert.IsNotNull(studentCourseRepository);
            Assert.IsNotNull(studentRepository);
            Assert.AreEqual(repositoryFactory.GetType(), typeof(RepositoryFactoryMock));
            Assert.AreEqual(courseRepository.GetType(), typeof(CourseRepositoryMock));
            Assert.AreEqual(studentCourseRepository.GetType(), typeof(StudentCourseRepositoryMock));
            Assert.AreEqual(studentRepository.GetType(), typeof(StudentRepositoryMock));
            Assert.AreEqual(RepositoryFactoryBase.RepositoryFactoryName, "Mocks.RepositoryFactoryMock");
            Assert.AreEqual(RepositoryFactoryBase.RepositoryFactoryNamespace, "GraduationTracker.Tests.Unit");

        }
    }
}