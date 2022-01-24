using GraduationTracker.ENUMS;
using GraduationTracker.Models.Interfaces;

namespace GraduationTracker.Models
{
    public class Student : BaseModel, IStudent
    {
        public int[] StudentCourses { get; set; }
        public STANDING Standing { get; set; } = STANDING.None;
    }
}
