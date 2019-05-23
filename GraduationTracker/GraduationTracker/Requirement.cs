namespace GraduationTracker
{
    public class Requirement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinimumMark { get; set; }
        public int Credits { get; set; }

        // No need to declare this as array because each Requirement has only one CourseId in Repository. Also changed it's name to CourseId from Courses.
        public int CourseId { get; set; }
    }
}
