using GraduationTracker.Domain.Entities;
using GraduationTracker.Domain.Interfaces.Repositories;
using GraduationTracker.Infra.MocData;
using System.Collections.Generic;

namespace GraduationTracker.Infra.Repositories
{
    public class DiplomaRepository : BaseRepository<Diploma>, IDiplomaRepository
    {
        public IEnumerable<Diploma> GetAll()
            => DiplomaData.GetDiplomas();
        
        public Diploma GetById(int id)
            => DiplomaData.GetDiplomas().Find(d => d.Id == id);
    }
}
