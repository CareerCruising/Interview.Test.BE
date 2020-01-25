using System.Collections.Generic;
using System.Linq;
using GraduationTracker.Models;
using GraduationTracker;
using GraduationTracker.Repositories;

namespace GraduationTracker.Services
{
    public class DiplomaService : IDiplomaRequirementService
    {
        private Diploma _diploma { get; }
        private IRepository<Requirement> _repository { get; }
        public Diploma Diploma => _diploma;

        public DiplomaService(Diploma diploma, IRepository<Requirement> repository)
        {
            _diploma = diploma;
            _repository = repository;
        }

        public IEnumerable<Requirement> GetRequirements()
        {
            return _diploma.Requirements.Select(requirement => _repository.GetById(requirement));
        }
    }
}