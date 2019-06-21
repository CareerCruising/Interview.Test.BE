namespace GraduationTracker.Models
{
    public class Requirement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinimumMark { get; set; }
        public int Credits { get; set; }
        public int[] Courses { get; set; }
    }
}
