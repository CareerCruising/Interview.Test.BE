namespace GraduationTracker.DML
{
    public class Course
    {
        private int _Id { get; set; }
        private string _Name { get; set; }
        private int _Mark { get; set; }
        private int _Credits { get; }

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public int Mark
        {
            get { return _Mark; }
            set { _Mark = value; }
        }

        public int Credits
        {
            get { return _Credits; }
        }

    }
}
