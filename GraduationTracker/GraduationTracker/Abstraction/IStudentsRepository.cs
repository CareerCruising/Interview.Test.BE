using GraduationTracker.Models;

namespace GraduationTracker.Abstraction
{
    public interface IStudentsRepository
    {
        Student GetStudent(int id);
    }
}