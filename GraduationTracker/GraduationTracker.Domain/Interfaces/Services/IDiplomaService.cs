using GraduationTracker.Domain.Entities;
using System.Collections.Generic;

namespace GraduationTracker.Domain.Interfaces.Services
{
    public interface IDiplomaService : IBaseService<Diploma>
    {
        Diploma GetById(int id);
        IEnumerable<Diploma> GetAll();
    }
}
