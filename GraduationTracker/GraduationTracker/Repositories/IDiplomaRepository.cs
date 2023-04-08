using GraduationTracker.Models;
using System.Collections.Generic;

namespace GraduationTracker.Repositories
{
    public interface IDiplomaRepository
    {
        IEnumerable<Diploma> GetDiplomas();

        Diploma GetDiploma(int id);
    }
}
