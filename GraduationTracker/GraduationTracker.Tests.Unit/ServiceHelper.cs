using GraduationTracker.Domain.Interfaces.Repositories;
using GraduationTracker.Domain.Interfaces.Services;
using GraduationTracker.Domain.Services;
using GraduationTracker.Infra.Repositories;

namespace GraduationTracker.Tests.Unit
{
    internal static class ServiceHelper
    {
        internal static IStudentService GetStudentService()
        {
            IStudentRepository repository = new StudentRepository();
            return new StudentService(repository);
        }

        internal static IDiplomaService GetDiplomaService()
        {
            IDiplomaRepository repository = new DiplomaRepository();
            return new DiplomaService(repository);
        }

        internal static ICourseService GetCourseService()
        {
            ICourseRepository repository = new CourseRepository();
            return new CourseService(repository);
        }
        internal static IRequirementService GetRequirementService()
        {
            IRequirementRepository repository = new RequirementRepository();
            return new RequirementService(repository);
        }
    }
}
