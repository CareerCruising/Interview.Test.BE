using GraduationTracker.Domain.Models;

namespace GraduationTracker.Domain.Interfaces
{
    public interface IStudentRepository
    {
        Student[] GetStudents();
    }
}
