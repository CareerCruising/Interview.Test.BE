using GraduationTracker.Models;
using GraduationTracker.Services;

namespace GraduationTracker
{
    public class GraduationTracker
    {

        private readonly IDiplomaRequirementService _diplomaService;

        private readonly IStudentService _studentService;

        public GraduationTracker(IDiplomaRequirementService diplomaService, IStudentService studentService)
        {
            _diplomaService = diplomaService;
            _studentService = studentService;
        }

        /// <summary>
        /// This method identifies whether student is graduated or not !!
        /// 
        ///  * Note Assumption made Student is graduated
        ///  1) if he has equal or more credits than credit offered by diploma 
        ///  2) Student's standing is not either remedial or none
        /// 
        /// </summary>
        /// <returns>Boolean</returns>
        public bool HasGraduated()
        {
            var standing = _studentService.GetStanding();
            var credits = _studentService.CalculateCredits(_diplomaService.GetRequirements());
            return credits >= _diplomaService.Diploma.Credits && (standing != Standing.Remedial && standing != Standing.None);
        }

        /// <summary>
        ///  This method identifies if student has earned any credits.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool HasCredits()
        {
            var credits = _studentService.CalculateCredits(_diplomaService.GetRequirements());
            return credits > 0;
        }
    }
}
