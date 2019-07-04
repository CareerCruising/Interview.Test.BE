using GraduationTracker.Domain.Entities;
using GraduationTracker.Domain.Interfaces.Repositories;
using GraduationTracker.Infra.MocData;
using System.Collections.Generic;

namespace GraduationTracker.Infra.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public IEnumerable<Student> GetAll()
            => StudentData.GetStudents();

        public Student GetById(int id)
            => StudentData.GetStudents().Find(s => s.Id == id);
    }
}
