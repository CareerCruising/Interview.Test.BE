using GraduationTracker.Models.Interfaces;

namespace GraduationTracker.Models
{
    public class Requirement : BaseModel, IRequirement
    {
        public string Name { get; set; }
        public float MinimumMark { get; set; }
        public int Credits { get; set; }
        public int Course { get; set; }
    }
}
