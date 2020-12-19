using GraduationTracker.Model;

namespace GraduationTracker.IGraduationTrackerServices
{
    public interface IRepositoryServices
    {
        Student GetStudent(int id);
        Diploma GetDiplomaByID(int id);
        Requirement GetRequirementByID(int id);
    }
}
