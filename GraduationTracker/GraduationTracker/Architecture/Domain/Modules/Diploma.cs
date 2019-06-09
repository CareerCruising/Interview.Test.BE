using System.Collections.Generic;

namespace GraduationTracker.Architecture.Domain.Modules
{
    public class Diploma
    {
        public Diploma()
        {
            Requirements = new List<Requirement>();
        }
        public int Id { get; set; }
        public int Credits { get; set; }
        public IEnumerable<Requirement> Requirements { get; set; }
    }
}
