using System.Collections.Generic;
using GraduationTracker.Architecture.Domain.Modules.Enumerator;

namespace GraduationTracker.Architecture.Domain.Modules
{
    public class Student
    {
        public Student()
        {
            Standing = EnumStanding.None;
            Courses = new List<Course>();
        }
        public int Id { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public EnumStanding Standing { get; set; }
    }
}
