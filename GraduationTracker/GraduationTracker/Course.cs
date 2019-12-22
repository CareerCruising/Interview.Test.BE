namespace GraduationTracker
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Mark { get; set; }
        // Unused. Never set in the Course declarations.
        public int Credits { get; }
    }
}
