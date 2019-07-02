using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void GetStudent_WhenStudentExists()
        {
            // Arrange, Act
            var student = Repository.GetStudent(1);

            // Assert
            Assert.IsNotNull(student);
        }

        [TestMethod]
        public void GetStudent_WhenStudentDoesNotExist()
        {
            // Arrange, Act
            var student = Repository.GetStudent(int.MaxValue);

            // Assert
            Assert.IsNull(student);
        }

        // Continune for GetDiploma() etc.
    }
}
