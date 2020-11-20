using GraduationTracker.Domain.Models;

namespace GraduationTracker.Domain.Interfaces
{
    public interface ICourseRepository
    {
        Course GetCourseByStudent(Student student, int id);
    }
}
