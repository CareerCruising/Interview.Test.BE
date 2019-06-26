namespace GraduationTracker
{
    public class Student
    {
        public int Id { get; set; }
        public Course[] Courses { get; set; }
        public Standing Standing { get; set; } = Standing.None;
    }
}
