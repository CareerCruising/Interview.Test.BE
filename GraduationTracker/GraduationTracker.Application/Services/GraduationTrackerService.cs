using GraduationTracker.Application.Interfaces;
using GraduationTracker.Domain.Enums;
using GraduationTracker.Domain.Interfaces;
using GraduationTracker.Domain.Models;

namespace GraduationTracker.Application.Services
{
    public class GraduationTrackerService : IGraduationTrackerService
    {
        private readonly IRequirementRepository _requirementRepository;
        private readonly ICourseRepository _courseRepository;

        public GraduationTrackerService(IRequirementRepository requirementRepository, ICourseRepository courseRepository)
        {
            _requirementRepository = requirementRepository;
            _courseRepository = courseRepository;
        }

        public int GetAverage(Diploma diploma, Student student)
        {
            var average = 0;

            foreach (var requirementId in diploma.Requirements) 
            {
                var requirement = _requirementRepository.GetRequirement(requirementId);

                foreach (var courseId in requirement.Courses) 
                {
                    average += _courseRepository.GetCourseByStudent(student, courseId).Mark;
                }
            }

            average = average / student.Courses.Length;

            return average;
        }

        public bool IsPassed(int average) => average >= 50;

        public STANDING GetStanding(int average)
        {
            if (average < 50)
                return STANDING.Remedial;
            else if (average >= 50 && average < 80)
                return STANDING.Average;
            else if (average >= 80 && average < 95)
                return STANDING.MagnaCumLaude;
            else if (average >= 90)
                return STANDING.SumaCumLaude;
            else
                return STANDING.None;
        }

        public int GetCredits(int[] requirements, Student student)
        {
            var credit = 0;

            foreach (var requirementId in requirements)
            {
                var requirement = _requirementRepository.GetRequirement(requirementId);

                foreach (var courseId in requirement.Courses)
                {
                    var course = _courseRepository.GetCourseByStudent(student, courseId);
                    credit = course.Mark >= 50 ? credit + requirement.Credits : credit;
                }
            }

            return credit;
        }
    }
}
