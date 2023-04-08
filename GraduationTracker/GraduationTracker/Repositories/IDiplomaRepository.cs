using GraduationTracker.Models;

namespace GraduationTracker.Repositories
{
    public interface IDiplomaRepository
    {
        Diploma[] GetDiplomas();

        Diploma GetDiploma(int id);
    }
}
