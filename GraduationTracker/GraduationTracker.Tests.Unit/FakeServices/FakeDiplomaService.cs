using System.Collections.Generic;
using GraduationTracker.Models;
using GraduationTracker.Services;

namespace GraduationTracker.Tests.Unit.FakeServices
{
    public class FakeDiplomaService : IDiplomaRequirementService
    {

        private IEnumerable<Requirement> _requirments { get; set; }

        public Diploma Diploma => _diploma;

        private readonly Diploma _diploma;

        public FakeDiplomaService(int diplomaCredit)
        {
            _diploma = new Diploma
            {
                Id = 100,
                Credits = diplomaCredit
            };
        }

        public IEnumerable<Requirement> GetRequirements()
        {
            return null;
        }
    }
}