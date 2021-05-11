using GraduationTracker.Courses;

namespace GraduationTracker
{
    public class Requirement : IRequirement
    {
        public int Id { get; set; }
        public int MinimumMark { get; set; }
        public int Credits { get; set; }
        public ICourse Course { get; set; }
    }
}
