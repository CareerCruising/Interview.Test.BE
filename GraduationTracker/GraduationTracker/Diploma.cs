using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker
{
    public class Diploma
    {
        public int Id { get; set; }
        public int Credits { get; set; }
        public IEnumerable<DiplomaRequirement> Requirements { get; set; }
        protected DiplomaRequirementRepository DiplomaRequirementRepository { get; set; }
        public Diploma(int id)
        {
            this.Id = id;
            this.DiplomaRequirementRepository = RepositoryFactoryBase.Instance.Value.CreateDiplomaRequirementRepository();
            this.Requirements = this.DiplomaRequirementRepository.GetRequirementByDiploma(this.Id);
        }

        public int GetCredits()
        {
            IEnumerable<Requirement> requirements = this.DiplomaRequirementRepository.GetRequirementsByDiplomaId(this.Id);

            foreach (Requirement requirement in requirements)
                this.Credits += requirement.GetCredits();

            return this.Credits;                 
        }

        public bool IsCoursePartOfDiploma(int courseId)
        {
            IEnumerable<Requirement> requirements = this.DiplomaRequirementRepository.GetRequirementsByDiplomaId(this.Id);

            foreach(Requirement requirement in requirements)
                if (requirement.IsCoursePartOfRequirement(courseId))
                    return true;

            return false;
        }

        public bool AreRequirementsMet(IEnumerable<StudentCourse> studentCourses)
        {
            IEnumerable<Requirement> requirements = this.DiplomaRequirementRepository.GetRequirementsByDiplomaId(this.Id);
            IDictionary<Requirement, bool> diplomaRequirementFufilled = requirements.ToDictionary(r => r, r => false);

            foreach(Requirement requirement in requirements)
                diplomaRequirementFufilled[requirement] = requirement.AreCourseRequirementsMet(studentCourses);

            return !diplomaRequirementFufilled.Any(drf => drf.Value == false);
        }    
    }
}
