using System;
using System.Linq;
using GraduationTracker.Models;
using GraduationTracker.Repositories;

namespace GraduationTracker
{
    public partial class GraduationTracker
    {
        private IRequirementRepository requirementRepository { get; set; }

        public GraduationTracker()
        {
            // In future we can pass object creation responsibility to dependency resolver
            // And use Constructor Injection to inject depdnecy for IRequirementRepository.
            requirementRepository = new RequirementRepository();
        }

        public Tuple<bool, STANDING> HasGraduated(Diploma diploma, Student student)
        {
            int credits = 0;
            int average = 0;

            foreach (int requirementId in diploma.Requirements)
            {
                var requirement = requirementRepository.GetRequirement(requirementId);

                foreach (var studentCourse in student.Courses)
                {
                    if (requirement.Courses.Contains(studentCourse.Id))
                    {
                        average += studentCourse.Mark;

                        if (studentCourse.Mark > requirement.MinimumMark)
                        {
                            // At this moment we are not using credit in calculation of Graduation.
                            // However, I'm keeping this calculation if we require it in a future.
                            // We can make seperate logic for calculating credit.
                            credits += requirement.Credits;
                        }
                    }
                }
            }

            average = student.Courses.ToList().Count > 0 ? average / student.Courses.ToList().Count : 0;

            return CalculateStanding(average);
        }

        private Tuple<bool, STANDING> CalculateStanding(int average)
        {
            switch (average)
            {
                case int when average < 50:
                    return new Tuple<bool, STANDING>(false, STANDING.Remedial);
                case int when average < 80:
                    return new Tuple<bool, STANDING>(true, STANDING.Average);
                case int when average < 95:
                default:
                    return new Tuple<bool, STANDING>(true, STANDING.MagnaCumLaude); ;
            }
        }
    }
}
