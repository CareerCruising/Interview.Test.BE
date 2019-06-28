/// <summary>
/// Requirement.cs file
/// </summary>
namespace GraduationTracker
{
    /// <summary>
    /// Requirement class
    /// </summary>
    public class Requirement
    {
        // Get & set requirement attributes
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinimumMark { get; set; }
        public int Credits { get; set; }
        public int[] Courses { get; set; }
    }
}
