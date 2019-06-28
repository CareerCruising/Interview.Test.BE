/// <summary>
/// Student.cs file
/// </summary>
namespace GraduationTracker
{
    /// <summary>
    /// Student class
    /// </summary>
    public class Student
    {
        // Get & set Student attributes
        public int Id { get; set; }
        public Course[] Courses { get; set; }
        public STANDING Standing { get; set; } = STANDING.None;
    }
}
