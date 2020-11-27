using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace GraduationTracker.Tests
{
    [TestClass()]
    public class RepositoryFactoryTests
    {
        [TestMethod()]
        public void RepositoryFactoryTest()
        {
            RepositoryFactoryBase repositoryFactory = new RepositoryFactory();

            Assert.IsNotNull(repositoryFactory);
            Assert.AreEqual(repositoryFactory.GetType(), typeof(RepositoryFactory));
        }

        [TestMethod()]
        public void CreateCourseRepositoryTest()
        {
            RepositoryFactoryBase repositoryFactory = new RepositoryFactory();
            CourseRepository courseRepository = repositoryFactory.CreateCourseRepository();

            Assert.IsNotNull(courseRepository);
            Assert.AreEqual(courseRepository.GetType(), typeof(CourseRepository));
        }

        [TestMethod()]
        public void CreateDiplomaRepositoryTest()
        {
            RepositoryFactoryBase repositoryFactory = new RepositoryFactory();
            DiplomaRepository diplomaRepository = repositoryFactory.CreateDiplomaRepository();

            Assert.IsNotNull(diplomaRepository);
            Assert.AreEqual(diplomaRepository.GetType(), typeof(DiplomaRepository));
        }

        [TestMethod()]
        public void CreateDiplomaRequirementRepositoryTest()
        {
            RepositoryFactoryBase repositoryFactory = new RepositoryFactory();
            DiplomaRequirementRepository diplomaRequirementRepository = repositoryFactory.CreateDiplomaRequirementRepository();

            Assert.IsNotNull(diplomaRequirementRepository);
            Assert.AreEqual(diplomaRequirementRepository.GetType(), typeof(DiplomaRequirementRepository));
        }

        [TestMethod()]
        public void CreateRequirementCourseRepositoryTest()
        {
            RepositoryFactoryBase repositoryFactory = new RepositoryFactory();
            RequirementCourseRepository requirementCourseRepository = repositoryFactory.CreateRequirementCourseRepository();

            Assert.IsNotNull(requirementCourseRepository);
            Assert.AreEqual(requirementCourseRepository.GetType(), typeof(RequirementCourseRepository));
        }

        [TestMethod()]
        public void CreateRequirementRepositoryTest()
        {
            RepositoryFactoryBase repositoryFactory = new RepositoryFactory();
            RequirementRepository requirementRepository = repositoryFactory.CreateRequirementRepository();

            Assert.IsNotNull(requirementRepository);
            Assert.AreEqual(requirementRepository.GetType(), typeof(RequirementRepository));
        }

        [TestMethod()]
        public void CreateStudentCourseRepositoryTest()
        {
            RepositoryFactoryBase repositoryFactory = new RepositoryFactory();
            StudentCourseRepository studentCourseRepository = repositoryFactory.CreateStudentCourseRepository();

            Assert.IsNotNull(studentCourseRepository);
            Assert.AreEqual(studentCourseRepository.GetType(), typeof(StudentCourseRepository));
        }

        [TestMethod()]
        public void CreateStudentRepositoryTest()
        {
            RepositoryFactoryBase repositoryFactory = new RepositoryFactory();
            DiplomaRepository diplomaRepository = repositoryFactory.CreateDiplomaRepository();
            Diploma diploma = diplomaRepository.GetDiploma().FirstOrDefault();
            StudentRepository studentRepository = repositoryFactory.CreateStudentRepository(diploma);

            Assert.IsNotNull(studentRepository);
            Assert.AreEqual(studentRepository.GetType(), typeof(StudentRepository));
        }
    }
}