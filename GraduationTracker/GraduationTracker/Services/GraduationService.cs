using GraduationTracker.Models;
using GraduationTracker.Repositories;
using System.Linq;

namespace GraduationTracker.Services
{
    public class GraduationService
    {
        private readonly RequirementRepository requirementRepository = new RequirementRepository();

        /// <summary>Determines whether the specified student has been graduated for given diploma.</summary>
        /// <param name="diploma">The diploma.</param>
        /// <param name="student">The student.</param>
        /// <returns>GraduateResult</returns>
        public GraduateResult HasGraduated(Diploma diploma, Student student)
        {
            var totalMarks = 0;

            foreach (var requirement in diploma.Requirements.Select(x => requirementRepository.GetItem(x)))
                foreach (var studentCourse in student.Courses)
                    foreach (var reqCource in requirement.Courses.Where(x => x == studentCourse.Id))
                    {
                        totalMarks += studentCourse.Mark;
                        studentCourse.Credits += (studentCourse.Mark >= requirement.MinimumMark) ? requirement.Credits : 0;
                    }

            var average = totalMarks / student.Courses.Length;

            var standing =
                (average < 50) ? Standing.Remedial :
                (average < 80) ? Standing.Average :
                (average < 95) ? Standing.MagnaCumLaude :
                                Standing.SummaCumLaude;

            var pass = standing > Standing.Remedial;
            return new GraduateResult() { Passed = pass, Status = standing };
        }
    }
}

