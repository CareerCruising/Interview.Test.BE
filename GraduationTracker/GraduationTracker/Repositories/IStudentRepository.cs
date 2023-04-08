using GraduationTracker.Models;

namespace GraduationTracker.Repositories
{
    public interface IStudentRepository
    {
        Student[] GetStudents();

        Student GetStudent(int id);
    }
}
