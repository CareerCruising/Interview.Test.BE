using GraduationTracker.Domain.Entities;
using System.Collections.Generic;

namespace GraduationTracker.Domain.Interfaces.Services
{
    public interface IStudentService : IBaseService<Student>
    {
        Student GetById(int id);
        IEnumerable<Student> GetAll();
    }
}
