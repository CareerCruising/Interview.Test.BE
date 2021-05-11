using GraduationTracker.Courses;

namespace GraduationTracker
{
    public interface IRequirement
    {
        int Id { get; set; }
        int MinimumMark { get; set; }
        int Credits { get; set; }
        ICourse Course { get; set; }
    }
}