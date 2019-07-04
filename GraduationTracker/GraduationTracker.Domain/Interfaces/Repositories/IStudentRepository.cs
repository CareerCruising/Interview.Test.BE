using GraduationTracker.Domain.Entities;
using System.Collections.Generic;

namespace GraduationTracker.Domain.Interfaces.Repositories
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        Student GetById(int id);
        IEnumerable<Student> GetAll();
    }
}
