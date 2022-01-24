
namespace GraduationTracker.Models.Interfaces
{
    public interface IStudentCourse : IBaseModel
    {
        int Student { get; }
        int Course { get; }
        float Mark { get; }
    }
}
