namespace GraduationTracker.Model
{
    public class Diploma : IEntity
    {
        public int Id { get; set; }
        public int Credits { get; set; }
        public int[] Requirements { get; set; }

        public int GetId()
        {
            return Id;
        }
    }
}
