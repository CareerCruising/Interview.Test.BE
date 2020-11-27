using System;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker
{
    public class DiplomaRequirementRepository
    {
        public DiplomaRequirementRepository()
        {

        }

        public void Add(DiplomaRequirement diplomaRequirement)
        {
            throw new NotImplementedException();
        }

        public void Update(DiplomaRequirement diplomaRequirement)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DiplomaRequirement> GetRequirementByDiploma(int diplomaId)
        {
            IEnumerable<DiplomaRequirement> diplomaRequirements = this.GetDiplomaRequirement();

            return diplomaRequirements.Where(dr => dr.DiplomaId == diplomaId);
        }

        public IEnumerable<Requirement> GetRequirementsByDiplomaId(int diplomaId)
        {
            IEnumerable<DiplomaRequirement> diplomaRequirements = this.GetDiplomaRequirement();
            RequirementRepository requirementRepository = RepositoryFactoryBase.Instance.Value.CreateRequirementRepository();
            ICollection<Requirement> requirements = new List<Requirement>();

            foreach (DiplomaRequirement dr in diplomaRequirements)
                requirements.Add(requirementRepository.GetRequirement(dr.RequirementId));

            return requirements;
        }

        public DiplomaRequirement GetDiplomaRequirement(int id)
        {
            IEnumerable<DiplomaRequirement> diplomaRequirements = this.GetDiplomaRequirement();

            return diplomaRequirements.SingleOrDefault(dr => dr.Id == id);
        }

        public virtual IEnumerable<DiplomaRequirement> GetDiplomaRequirement()
        {
            return new List<DiplomaRequirement>()
            {
                new DiplomaRequirement()
                {
                    Id = 1,
                    DiplomaId = 1,
                    RequirementId = 100
                },
                new DiplomaRequirement()
                {
                    Id = 2,
                    DiplomaId = 1,
                    RequirementId = 102
                },
                new DiplomaRequirement()
                {
                    Id = 3,
                    DiplomaId = 1,
                    RequirementId = 103
                },
                new DiplomaRequirement()
                {
                    Id = 4,
                    DiplomaId = 1,
                    RequirementId = 104
                }
            };
        }
    }
}
