using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    /// <summary>
    /// This class represents a student.
    /// </summary>
    public class Student
    {
        public int Id { get; set; }
        public Course[] Courses { get; set; }
        public STANDING Standing { get; set; } = STANDING.None;
    }
}