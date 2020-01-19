using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        private GraduationTracker Tracker { get; set; }

        public GraduationTrackerTests()
        {
            Tracker = new GraduationTracker();
        }

        private Student GetStudent(int id, int mark)
        {
            return new Student
            {
                Id = id,
                Courses = new Course[]
                    {
                        new Course{ Id = 1, Name = "Math", Mark = mark },
                        new Course{ Id = 2, Name = "Science", Mark = mark },
                        new Course{ Id = 3, Name = "Literature", Mark = mark },
                        new Course{ Id = 4, Name = "Physichal Education", Mark = mark }
                    }
            };
        }

        private Diploma GetDiploma(int credits, int[] requirements)
        {
            return new Diploma
            {
                Id = 1,
                Credits = credits,
                Requirements = requirements
            };
        }

        [DataTestMethod]
        [DataRow(100, 95, true, Standing.SumaCumLaude)]
        [DataRow(200, 94, true, Standing.MagnaCumLaude)]
        [DataRow(300, 80, true, Standing.MagnaCumLaude)]
        [DataRow(400, 79, true, Standing.Average)]
        [DataRow(500, 50, true, Standing.Average)]
        [DataRow(600, 49, false, Standing.Remedial)]
        [DataRow(700, 40, false, Standing.Remedial)]
        [DataRow(800, 0, false, Standing.Remedial)]
        public void TestHasGraduated(int id, int mark, bool hasGratuated, Standing standing)
        {
            var diploma = GetDiploma(4, new int[] { 100, 102, 103, 104 });
            var student = GetStudent(id, mark);
            var result = Tracker.HasGraduated(diploma, student);

            Assert.AreEqual(hasGratuated, result.Item1);
            Assert.AreEqual(standing, result.Item2);
        }
    }
}
