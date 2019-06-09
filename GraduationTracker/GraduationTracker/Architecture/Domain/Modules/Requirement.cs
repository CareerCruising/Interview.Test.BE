using System.Collections.Generic;

namespace GraduationTracker.Architecture.Domain.Modules
{
    public class Requirement
    {
        public Requirement()
        {
            Courses = new List<Course>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinimumMark { get; set; }
        public int Credits { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}
