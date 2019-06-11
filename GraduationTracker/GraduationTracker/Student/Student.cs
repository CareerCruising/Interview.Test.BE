namespace GraduationTracker
{
    public class Student : Base
    {
        public CourseMark[] Courses { get; set; }

        public Standing Standing { get; set; } = Standing.None;
    }
}
