using GraduationTracker.Models.Interfaces;

namespace GraduationTracker.Models
{
    public class Diploma : BaseModel, IDiploma
    {
        public int Credits { get; set; }
        public int[] Requirements { get; set; }
    }
}
