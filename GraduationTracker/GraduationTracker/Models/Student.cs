using GraduationTracker.Services;

namespace GraduationTracker.Models
{
    public class Student: IEntity
    {
        public int Id { get; set; }
        public Course[] Courses { get; set; }
        public Standing Standing { get; set; } = Standing.None;
    }
}
