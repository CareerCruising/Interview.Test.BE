namespace GraduationTracker
{
    public class Student
    {
        public int Id { get; set; }
        public Course[] Courses { get; set; }

        // This is not being used but we can calculate Standing of a Student from Graduation Tracker and assign to this variable. So not commenting it out.
        public STANDING Standing { get; set; } = STANDING.None;
    }
}
