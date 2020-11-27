namespace GraduationTracker.Tests.Unit.Mocks
{
    public class RepositoryFactoryMock : RepositoryFactoryBase
    {
        public RepositoryFactoryMock() : base()
        {

        }

        public override CourseRepository CreateCourseRepository()
        {
            return new CourseRepositoryMock();
        }

        public override DiplomaRepository CreateDiplomaRepository()
        {
            return new DiplomaRepository();
        }

        public override DiplomaRequirementRepository CreateDiplomaRequirementRepository()
        {
            return new DiplomaRequirementRepository();
        }

        public override RequirementCourseRepository CreateRequirementCourseRepository()
        {
            return new RequirementCourseRepository();
        }

        public override RequirementRepository CreateRequirementRepository()
        {
            return new RequirementRepository();
        }

        public override StudentCourseRepository CreateStudentCourseRepository()
        {
            return new StudentCourseRepositoryMock();
        }

        public override StudentRepository CreateStudentRepository(Diploma diploma)
        {
            return new StudentRepositoryMock(diploma);
        }
    }
}
