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

        public GraduatedModel HasGraduated(Diploma diploma, Student student)
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

            int courseCount = student.Courses.ToList().Count;

            average = courseCount > 0 ? average / courseCount : 0;

            return CalculateStanding(average);
        }

        private GraduatedModel CalculateStanding(int average)
        {
            GraduatedModel graduatedModel = new GraduatedModel();
            switch (average)
            {
                case int when average == 0:
                    graduatedModel.Standing = STANDING.None;
                    break;
                case int when average < 50:
                    graduatedModel.Standing = STANDING.Remedial;
                    break;
                case int when average < 80:
                    graduatedModel.IsGraduated = true;
                    graduatedModel.Standing = STANDING.Average;
                    break;
                case int when average < 95:
                default:
                    graduatedModel.IsGraduated = true;
                    graduatedModel.Standing = STANDING.MagnaCumLaude;
                    break;
            }
            return graduatedModel;
        }
    }
}
