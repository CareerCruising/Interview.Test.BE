using GraduationTracker.Models;

namespace GraduationTracker
{
    public class Diploma : IPrimaryKey
    {
        public int Id { get; set; }
        public int Credits { get; set; }
        public int[] Requirements { get; set; }
    }
}
