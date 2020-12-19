using GraduationTracker.Model.Enum;

namespace GraduationTracker.Model
{
    public class Student
    {
        public int Id { get; set; }
        public Course[] Courses { get; set; }
        public STANDING Standing { get; set; } = STANDING.None;
    }
}
