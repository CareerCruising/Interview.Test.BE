using System.Linq;
using GraduationTracker.Architecture.Domain.Modules;
using GraduationTracker.Architecture.Domain.Modules.Repository;
using GraduationTracker.Architecture.Mock;

namespace GraduationTracker.Architecture.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public Student GetStudent(int id)
        {
            return StudentMoq.GetStudents().SingleOrDefault(x => x.Id == id);
        }
    }
}
