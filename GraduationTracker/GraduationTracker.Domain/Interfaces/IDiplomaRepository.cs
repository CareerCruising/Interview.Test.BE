using GraduationTracker.Domain.Models;

namespace GraduationTracker.Domain.Interfaces
{
    public interface IDiplomaRepository
    {
        Diploma[] GetDiplomas();
        Diploma GetDiploma(int id);
    }
}
