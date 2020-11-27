using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker.Tests.Unit.Mocks
{
    public class StudentRepositoryMock : StudentRepository
    {
        public StudentRepositoryMock(Diploma diploma) : base(diploma)
        {

        }

        public override IEnumerable<Student> GetStudent()
        {
            return new[]
            {
               new Student(this.Diploma, 1),
               new Student(this.Diploma, 2),
               new Student(this.Diploma, 3),
               new Student(this.Diploma, 4),
               new Student(this.Diploma, 5),
               new Student(this.Diploma, 6)
            };
        }
    }
}
