namespace GraduationTracker.Model
{
    public class Course : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Mark { get; set; }
        public int Credits { get; }

        public int GetId()
        {
            return Id;
        }
    }
}
