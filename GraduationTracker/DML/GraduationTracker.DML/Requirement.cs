using System.Collections.Generic;

namespace GraduationTracker.DML
{
    public class Requirement
    {
        private int _Id;
        private string _Name;
        private int _MinimumMark;
        private int _Credits;
        private List<Course> _Courses;

        public int Id {
            get { return _Id; }
            set { _Id = value; }
        }
        public string Name {
            get { return _Name; }
            set { _Name = value; }
        }
        public int MinimumMark {
            get { return _MinimumMark; }
            set { _MinimumMark = value; }
        }
        public int Credits {
            get { return _Credits; }
            set { _Credits = value; }
        }
        public List<Course> Courses {
            get { return _Courses; }
            set { _Courses = value; }
        }
    }
}
