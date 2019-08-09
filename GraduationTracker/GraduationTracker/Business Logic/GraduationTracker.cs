using GraduationTracker.Models;
using GraduationTracker.Repositories;
using System.Linq;

namespace GraduationTracker.Business_Logic
{
    public class GraduationTracker
    {
        private readonly RequirementRepository _requirementRepository = new RequirementRepository();

    
        public CourseResult HasGraduated(Diploma diploma, Student student)
        {
            int  totalMarks = CalculateTotalMarks(diploma,student);


            int average = totalMarks / student.Courses.Length;

            Standing standing = GetStanding(average);
            bool testPassed = GetResultStatus(standing);

            
            return new CourseResult() { Passed = testPassed, Status = standing };
        }

        private bool GetResultStatus(Standing standing)
        {
            return ((standing != Standing.Remedial) && (standing!=Standing.None));
        }

        public Standing GetStanding(int average)
        {
            return (average < 50) ? Standing.Remedial :
                (average < 80) ? Standing.Average :
                (average < 95) ? Standing.MagnaCumLaude :
                Standing.SumaCumLaude;

        }

        public int CalculateTotalMarks(Diploma diploma, Student student)
        {
            int totalMarks = 0;
            foreach (var diplomaRequirements in diploma.Requirements.Select(x => _requirementRepository.GetItem(x)))
            foreach (var studentCourses in student.Courses)
            foreach (var matchingCourse in diplomaRequirements.Courses.Where(x => x == studentCourses.Id))
            {
                totalMarks += studentCourses.Mark;
                studentCourses.Credits += (studentCourses.Mark >= diplomaRequirements.MinimumMark)? diplomaRequirements.Credits: 0;
            }

            return totalMarks;
        }
    }
}