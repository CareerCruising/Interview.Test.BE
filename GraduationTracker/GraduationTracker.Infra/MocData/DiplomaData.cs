using GraduationTracker.Domain.Entities;
using GraduationTracker.Infra.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Infra.MocData
{
    public static class DiplomaData
    {
        public static List<Diploma> GetDiplomas()
        {
            var _requirementRepository = new RequirementRepository();
            var requirements = _requirementRepository.GetAll();

            return new List<Diploma>()
            {
                new Diploma
                {
                    Id = 1,
                    Credits = 4,
                    Requirements = requirements.ToList()
                }
            };
        }
    }
}
