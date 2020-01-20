namespace GraduationTracker.Model
{
    public class Student : IEntity
    {
        public int Id { get; set; }
        public Course[] Courses { get; set; }
        public Standing Standing { get; set; } = Standing.None;

        public int GetId()
        {
            return Id;
        }
    }
}
