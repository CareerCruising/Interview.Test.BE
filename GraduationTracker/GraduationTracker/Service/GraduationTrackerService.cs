using GraduationTracker.Model;
using GraduationTracker.Repository.Core;
using System;
using System.Linq;

namespace GraduationTracker.Service
{
    public class GraduationTrackerService
    {
        public IUnitOfWork UnitOfWork { get; }

        public GraduationTrackerService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public Tuple<bool, Standing> HasGraduated(Diploma diploma, Student student)
        {
            if (diploma == null) throw new ArgumentException("Invalid diploma.");
            if (student == null) throw new ArgumentException("Invalid student.");

            //TODO: credits variable needs business logic definition to be used and validated in the code
            var credits = 0;
            var average = 0;
            var requirements = GetDiplomaRequirements(diploma);

            foreach (var requirement in requirements)
            {
                foreach (var courseId in requirement.Courses)
                {
                    var course = student.Courses.FirstOrDefault(studentCourse => studentCourse.Id == courseId);
                    // It was assumed that all courses in the diploma requirements should be also in the student course list,
                    // otherwise the student is considered not graduated
                    if (course == null) return new Tuple<bool, Standing>(false, Standing.None);

                    average += course.Mark;
                    //TODO: there is some logic related to credits, but I am not sure how the results should be validated
                    if (course.Mark > requirement.MinimumMark)
                        credits += requirement.Credits;
                }
            }

            // Average calculation was affected by validation of the requirements:
            // previously, it would consider only the intersection of requirements vs. students courses
            // now, if the requirements are not met a response will be returned prior to this calculation
            average /= student.Courses.Length;

            if (average < 50)
                return new Tuple<bool, Standing>(false, Standing.Remedial);
            else if (average < 80)
                return new Tuple<bool, Standing>(true, Standing.Average);
            else if (average < 95)
                return new Tuple<bool, Standing>(true, Standing.MagnaCumLaude);
            else
                return new Tuple<bool, Standing>(true, Standing.SumaCumLaude);            
        }

        private Requirement[] GetDiplomaRequirements(Diploma diploma) 
        {
            return UnitOfWork.Requirements
                .Find(requirement => diploma.Requirements.Contains(requirement.Id))
                .ToArray();
        }
    }
}
