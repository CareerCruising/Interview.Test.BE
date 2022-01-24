using GraduationTracker.Models.Interfaces;

namespace GraduationTracker.Models
{
    public class Course : BaseModel, ICourse
    {
        public string Name { get; set; }
        public int Credits { get; }
     }
}
