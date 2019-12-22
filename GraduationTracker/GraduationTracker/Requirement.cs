namespace GraduationTracker
{
    public class Requirement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // I'm assuming this is the minimum mark to gain a credit from a course in Requirement.Courses
        public int MinimumMark { get; set; }
        // Does this represent the Credits required to meet this requirement, or the Credits gained by completing this requirement?
        // If this is the required number of Credits, is that not already covered by Requirement.Courses?
        public int Credits { get; set; }
        // References Course.Id
        public int[] Courses { get; set; }
    }
}
