namespace GraduationTracker
{
    public class StudentCourse
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int Mark { get; set; }
        protected StudentCourseRepository studentCourseRepository { get; set; }
        public StudentCourse()
        {
            this.studentCourseRepository = RepositoryFactoryBase.Instance.Value.CreateStudentCourseRepository();
        }

        public void Add()
        {
            //Validation input and massage data logic goes here
            //This is the visitor pattern used in 3 tiered architecture
            this.studentCourseRepository.Add(this);
        }

        public void Update()
        {
            //Validation input and massage data logic goes here
            //This is the visitor pattern used in 3 tiered architecture
            this.studentCourseRepository.Update(this);
        }

        public void Delete()
        {
            //Validations for delete and business logic goes here
            this.studentCourseRepository.Delete(this.StudentId);
        }

        public bool IsCoursePassed(int minimumMark)
        {
            return Mark >= minimumMark;
        }
    }
}
