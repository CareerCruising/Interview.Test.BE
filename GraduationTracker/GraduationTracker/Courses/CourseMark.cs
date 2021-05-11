using System;
namespace GraduationTracker.Courses
{
    public class CourseMark : Course, ICourseMark
    {
        public CourseMark()
        {
        }

        public int Mark { get; set; }
    }
}
