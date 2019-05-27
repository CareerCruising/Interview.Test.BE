using System.Collections.Generic;

namespace GraduationTracker.DML
{
    public class Diploma
    {
        private int _Id;
        private int _Credits;
        private List<Requirement> _Requirements;

        public int Id {
            get { return _Id; }
            set { _Id = value; }
        }
        public int Credits {
            get { return _Credits; }
            set { _Credits = value; }
        }
        public List<Requirement> Requirements {
            get { return _Requirements; }
            set { _Requirements = value; }
        }
    }
}
