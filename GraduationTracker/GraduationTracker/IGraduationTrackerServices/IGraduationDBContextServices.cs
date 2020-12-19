using GraduationTracker.Model;

namespace GraduationTracker.IGraduationTrackerServices
{
    interface IGraduationDBContextServices
    {
        Student[] GetAllStudent();
        Diploma[] GetAllDiploma();
        Requirement[] GetAllRequirements();
    }
}
