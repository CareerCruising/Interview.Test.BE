using GraduationTracker.Models;

namespace GraduationTracker.Abstraction
{
    public interface IDiplomasRepository
    {
        Diploma GetDiploma(int id);
    }
}