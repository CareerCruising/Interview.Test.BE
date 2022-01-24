
namespace GraduationTracker.Models.Interfaces
{
    public interface IStudent : IBaseModel
    {
        int[] StudentCourses { get; }
    }
}
