using GraduationTracker.Models;

namespace GraduationTracker
{
    public class Course :IPrimaryKey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Mark { get; set; }
        public int Credits { get; internal set; }
    }
}
