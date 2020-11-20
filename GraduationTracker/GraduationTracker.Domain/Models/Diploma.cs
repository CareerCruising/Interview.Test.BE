namespace GraduationTracker.Domain.Models
{
    public class Diploma
    {
        public int Id { get; set; }
        public int Credits { get; set; }
        public int[] Requirements { get; set; }
    }
}
