using System.Linq;
using GraduationTracker.Architecture.Domain.Modules;
using GraduationTracker.Architecture.Domain.Modules.Repository;
using GraduationTracker.Architecture.Mock;

namespace GraduationTracker.Architecture.Repository
{
    public class DiplomaRepository : IDiplomaRepository
    {
        public Diploma GetDiploma(int id)
        {
            return DiplomaMoq.GetDiplomas().SingleOrDefault(x => x.Id == id);
        }
    }
}
