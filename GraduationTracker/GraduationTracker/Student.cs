namespace GraduationTracker
{
    public class Student
    {
        public int Id { get; set; }
        public Course[] Courses { get; set; }
        // Unused. Never set in the Student declarations.
        public STANDING Standing { get; set; } = STANDING.None;
    }
}
