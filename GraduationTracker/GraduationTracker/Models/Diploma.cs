using System.Collections.Generic;

namespace GraduationTracker.Models
{
    public class Diploma
    {
        public int Id { get; set; }
        public int Credits { get; set; }
        public IEnumerable<int> Requirements { get; set; }
    }
}
