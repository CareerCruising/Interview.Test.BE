namespace GraduationTracker.Model
{
    public class Requirement : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinimumMark { get; set; }
        public int Credits { get; set; }
        public int[] Courses { get; set; }

        public int GetId()
        {
            return Id;
        }
    }
}
