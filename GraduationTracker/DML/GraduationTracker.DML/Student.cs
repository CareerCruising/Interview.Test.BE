using System.Collections.Generic;

namespace GraduationTracker.DML
{
    public class Student
    {
        private int _Id;
        private List<Course> _Courses;
        private STANDING _Standing;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public List<Course> Courses
        {
            get { return _Courses; }
            set { _Courses = value; }
        }

        public STANDING Standing
        {
            get { return _Standing; }
            set { _Standing = value; }
        }
    }
}
