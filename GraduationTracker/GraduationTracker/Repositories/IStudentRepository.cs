using GraduationTracker.Models;
using System.Collections.Generic;

namespace GraduationTracker.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();

        Student GetStudent(int id);
    }
}
