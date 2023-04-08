using System.Collections.Generic;

namespace GraduationTracker.Models
{
    public class Student
    {
        public int Id { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public STANDING Standing { get; set; } = STANDING.None;
    }
}
