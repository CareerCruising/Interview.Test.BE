using GraduationTracker.DBContext;

namespace GraduationTracker.IGraduationTrackerServices
{
    class GraduationDBServicesController : IGraduationDBContextServices
    {
        public Diploma[] GetAllDiploma()
        {
            return GraduationDBContext.Diplomas;
        }

        public Requirement[] GetAllRequirements()
        {
            return GraduationDBContext.Requirements;
        }

        public Student[] GetAllStudent()
        {
            return GraduationDBContext.Students;
        }
    }
}
