using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public class Student
    {
        public Student()
        {
            Standing = STANDING.None;
        }
        public int Id { get; set; }
        public List<Course> Courses { get; set; }
        public STANDING Standing { get; set; }  
    }
}
