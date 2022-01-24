using GraduationTracker.Models.Interfaces;

namespace GraduationTracker.Models
{
    public class StudentCourse : BaseModel, IStudentCourse
    {
        public float Mark { get; set; }
        public int Student { get; set; }
        public int Course { get; set; }
    }
}
