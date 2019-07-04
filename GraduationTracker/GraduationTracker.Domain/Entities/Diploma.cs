using System.Collections.Generic;

namespace GraduationTracker.Domain.Entities
{
    public class Diploma
    {
        public int Id { get; set; }
        public int Credits { get; set; }
        public List<Requirement> Requirements { get; set; }
    }
}
