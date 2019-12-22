using System;
using System.Linq;

namespace GraduationTracker
{
    public partial class GraduationTracker
    {
        public Tuple<bool, STANDING> HasGraduated(Diploma diploma, Student student)
        {
            /*
             * The criteria for graduation is unclear
             * 
             * The existing code seems to make this assumption:
             * - For all Courses tied to a Requirement, the average Course.Mark must be >= 50 in order for the Student to have graduated with that Diploma
             * 
             * It also seems to not account for multiple requirements referencing the same course. In that case, a course may be included twice, skewing the average.
             *
             * I am making the following assumptions:
             * 1. Each Requirement in Diploma.Requirements must be met in order for the Student to have graduated with that Diploma
             * 2. Each Course in Requirement.Courses must be passed in order for the Requirement to be considered met
             * 3. A Course must have a Course.Mark >= Requirement.MinimumMark in order for the Course to be considered passed
             * 4. The average determining the student's Standing includes all courses the student has taken.
             * 5. Each student only ever takes a particular course once
             *
             * Other possible criteria I could have considered:
             * - The sum of Requirement.Credits for all met Requirements >= Diploma.Credits in order for the Student to have graduated with that Diploma
             * - The sum of Course.Credits for all passed Courses >= Requirement.Credits in order for the Requirement to be considered met
             *      (This would mean that assumption #2 above wouldn't be necessary, and some failed courses would be allowed)
             * - The sum of Course.Credits for all passed Courses >= Diploma.Credits in order for the Student to have graduated with that Diploma
             *      (For courses not tied to a requirement, would would be the criteria for a "passing course"?) 
             */

            bool hasGraduated = diploma.Requirements.All(requirementId =>
            {
                Requirement requirement = Repository.GetRequirement(requirementId);

                bool requirementMet = requirement.Courses.All(courseId =>
                {
                    Course course = Array.Find(student.Courses, c => c.Id == courseId);

                    // If required Course could not be found, requirement is not met
                    if (course is null)
                    {
                        return false;
                    }

                    // If Course mark is not high enough, requirement is not met
                    bool coursePassed = course.Mark >= requirement.MinimumMark;

                    return coursePassed;
                });

                return requirementMet;
            });

            // This includes all courses, even ones not in a requirement.
            // If we only wanted courses belonging to requirements, I'd filter/where the list beforehand
            int totalMarks = student.Courses.Select(s => s.Mark).Sum();
            int average = totalMarks / student.Courses.Length;

            STANDING standing;
            if (average < 50)
            {
                standing = STANDING.Remedial;
            }
            else if (average < 80)
            {
                standing = STANDING.Average;
            }
            else if (average < 95)
            {
                standing = STANDING.SumaCumLaude;
            }
            else
            {
                standing = STANDING.MagnaCumLaude;
            }

            return new Tuple<bool, STANDING>(hasGraduated, standing);
        }
    }
}
